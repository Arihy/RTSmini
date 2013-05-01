using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingCircle : Building
{
	public GameObject spawnTop;
	public GameObject spawnBot;
	public GameObject spawnRight;
	public GameObject spawnLeft;
	
	public int sTop = 0;
	public int sRight = 1;
	public int sBot = 2;
	public int sLeft = 3;
	
	public bool[] spawn = {false, false, false, false};
	
    public GameObject prefabUnit;
    private int supportMax;
	private int countSupport = 0;
    private List<GameObject> support = new List<GameObject>();
	
	//STATES
	public StateBuildingCircle STATE_DIE ;
	public StateBuildingCircle STATE_IDLE;
	public StateBuildingCircle STATE_PROD;
	
	private StateBuildingCircle currentState;
    
	public int getLastProdCount()
	{
		return countSinceLastProd;
	}
	
	public void incrementLastProdCount()
	{
		countSinceLastProd ++;
	}
	
	public void resetLastProdCount()
	{
		countSinceLastProd = 0;
	}
	
	public void setCurrentState(StateBuildingCircle newState)
	{
		currentState = newState;
	}
	
    public int getNbSupportMax()
    {
        return supportMax;
    }

    public int getNbSupport()
    {
        return countSupport;
    }

    public List<GameObject> getSupport()
    {
        return support;
    }

    public bool addSupport(GameObject go)
    {
        if (countSupport < supportMax && !support.Contains(go))
        {
            support.Add(go);
            countSupport++;
            return true;
        }
        return false;
    }

    public bool removeSupport(GameObject go)
    {
		//Debug.Log("Remove Support!!!");
        if (countSupport > 0 && support.Contains(go))
        {
            support.Remove(go);
            countSupport--;
            return true;
        }
        return false;
    }
	
	public GameObject createUnit(GameObject spawnPoint)
	{
		return (GameObject)Instantiate(prefabUnit, spawnPoint.transform.position, Quaternion.identity);
	}
	
	//STATE delegation
	
	public void playAnim()
	{
		currentState.playAnim();
	}
	
	public void die()
	{
		currentState.die();
	}
	
	public void prod()
	{
		currentState.prod();
	}
	
	public void checkNewState()
	{
		currentState.checkNewState();
	}

    // Use this for initialization
    public override void Start()
    {
        base.Start();
		STATE_DIE = new DieStateBuildingCircle(gameObject);
		STATE_PROD = new ProdStateBuildingCircle(gameObject);
		STATE_IDLE = new IdleStateBuildingCircle(gameObject);
		currentState = STATE_PROD;
		env = Environnement.getUniqueEnv();
        //enregistremet du batiment auprès de l'environnement
        env.addProd(gameObject);
        delayBetweenProd = 120;
        countSinceLastProd = 0;
        countUnits = 0;
        supportMax = 4;
		setInitialEnergy(10.0f);
		
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
		playAnim();
		prod();
		die();
		checkNewState();
    }
}
