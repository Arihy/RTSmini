using UnityEngine;
using System.Collections;

public class ProdStateBuildingCircle : AliveStateBuildingCircle {
	
	public ProdStateBuildingCircle(GameObject newGoBuildingCircle)
    {
        goBuildingCircle = newGoBuildingCircle;
    }
	
	public override void playAnim()
	{
		BuildingCircle prod = goBuildingCircle.GetComponent<BuildingCircle>() ;
		//Debug.Log("Bat " + goBuildingCircle.GetComponent<BuildingCircle>().getId() + " : STATE PROD");
	}
	
	public override void checkOtherState()
	{
		BuildingCircle prod = goBuildingCircle.GetComponent<BuildingCircle>() ;
		//Debug.Log("Bat " + goBuildingCircle.GetComponent<BuildingCircle>().getId() + " nb prodSupport : " + prod.getNbSupport());
		if(prod.getNbSupport() >= prod.getNbSupportMax()) prod.setCurrentState(prod.STATE_IDLE);
		else prod.setCurrentState(prod.STATE_PROD);
	}
	
	public override void prod()
	{
		//Debug.Log("Bat " + goBuildingCircle.GetComponent<BuildingCircle>().getId() + " :PROD !!!");
		BuildingCircle prod = goBuildingCircle.GetComponent<BuildingCircle>() ;
		//Debug.Log("Bat " + prod.getId() + " :PROD !!! prodCount : " + prod.getLastProdCount() + " delay : " + prod.getDelayBetweenProd());
		if(prod.getLastProdCount() >= prod.getDelayBetweenProd())
		{
		//	Debug.Log("Bat " + goBuildingCircle.GetComponent<BuildingCircle>().getId() + " :PROD !!! delay ok");
			//créer une unité - prefab CirlcleUnits
            //Vector3 position = transform.position + transform.localScale / 2 + prefabUnit.transform.localScale / 2 + countUnits * (transform.localScale / 2 + prefabUnit.transform.localScale / 2);
			//Vector3 position = transform.position + renderer.bounds.size / 2 + prefabUnit.renderer.bounds.size / 2 + countUnits * (renderer.bounds.size / 2 + prefabUnit.renderer.bounds.size / 2);
			//lastUnit = (GameObject)Instantiate(prefabUnit, position, Quaternion.identity);
            
			//if(!prod.spawn[prod.sTop])
			if(prod.spawnTop.GetComponent<SpawnManager>().getAvailability())
			{
				//prod.spawn[prod.sTop] = true;
				prod.lastUnit = prod.createUnit(prod.spawnTop);
				//prod.audioProd.Play();
				//prod.lastUnit = (GameObject)goBuildingCircle.Instantiate(goBuildingCircle.prefabUnit, goBuildingCircle.spawnTop.transform.position, goBuildingCircle.Quaternion.identity);
				unitSubscription(prod.lastUnit , prod);
			}
			else if(prod.spawnBot.GetComponent<SpawnManager>().getAvailability())//if(!prod.spawn[prod.sBot])
			{
				//prod.spawn[prod.sBot] = true;
				prod.lastUnit = prod.createUnit(prod.spawnBot);
				//prod.audioProd.Play();
				//prod.lastUnit = (GameObject)Instantiate(prod.prefabUnit, prod.spawnBot.transform.position, Quaternion.identity);
				unitSubscription(prod.lastUnit , prod);
			}
			else if(prod.spawnLeft.GetComponent<SpawnManager>().getAvailability())//if(!prod.spawn[prod.sLeft])
			{
				//prod.spawn[prod.sLeft] = true;
				prod.lastUnit = prod.createUnit(prod.spawnLeft);
				//prod.audioProd.Play();
				//prod.lastUnit = (GameObject)Instantiate(prod.prefabUnit, prod.spawnLeft.transform.position, Quaternion.identity);
				unitSubscription(prod.lastUnit , prod);
			}
			else if(prod.spawnRight.GetComponent<SpawnManager>().getAvailability())//if(!prod.spawn[prod.sRight])
			{
				//prod.spawn[prod.sRight] = true;
				prod.lastUnit = prod.createUnit(prod.spawnRight);
				//prod.audioProd.Play();
				//prod.lastUnit = (GameObject)Instantiate(prod.prefabUnit, prod.spawnRight.transform.position, Quaternion.identity);
				unitSubscription(prod.lastUnit , prod);
			}
			else
			{
				//Debug.Log("Bat " + goBuildingCircle.GetComponent<BuildingCircle>().getId() + " :PROD !!! finaly no prod... no spawn dispo");
				prod.incrementLastProdCount();
			}
		}
		else prod.incrementLastProdCount();
	}
	
	private void unitSubscription(GameObject unit, BuildingCircle prod)
	{
		//il faut définir la team de l'unité
        unit.GetComponent<CircleUnits>().setTeam(prod.getTeam());
        Environnement env = Environnement.getUniqueEnv();
        //on ajoute l'unité à l'environnement
        env.addUnit(unit);
        prod.incrementCountUnit();
		//on diminue l'energy du bat de prod
		prod.reduceEnergy(1.0f);
		//on reset le compte de prod
		prod.resetLastProdCount();
	}
}
