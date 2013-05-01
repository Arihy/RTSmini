using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IdleStateCircleUnit : RightClickableStateCircleUnit
{

    public IdleStateCircleUnit(GameObject newGoCircleUnit)
    {
        goCircleUnit = newGoCircleUnit;
    }

    public override void playAnim()
    {
       	//Debug.Log("CircleUnit " + goCircleUnit.GetComponent<CircleUnits>().getId() + " is IDLE");
        //TODO
    }

    public override void checkOtherState2()
    {
        CircleUnits unit = goCircleUnit.GetComponent<CircleUnits>();
		List<GameObject> prodsTriangle = unit.getProximityTriangleProds();
		if(prodsTriangle.Count > 0)
		{
			prodsTriangle[0].GetComponent<BuildingTriangle>().suscribe();
			unit.setCurrentState(unit.STATE_TRIANGLEPROD);
		}
		else
		{
	        List<GameObject> enemies = unit.getProximityEnemies();
	        if (enemies.Count > 0) unit.setCurrentState(unit.STATE_ATTACK);
			else 
			{
				List<GameObject> prods = unit.getProximityProds();
				if(prods.Count > 0)
				{
					//Corriger en while ...
					foreach(GameObject prod in prods)
					{
						if(prod.GetComponent<BuildingCircle>().getNbSupport() < prod.GetComponent<BuildingCircle>().getNbSupportMax())
						{
							if(unit.suscribeSupport(prod)) unit.setCurrentState(unit.STATE_PROD);
						}
					}
				}
			}
		}
    }
}
