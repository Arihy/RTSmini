using UnityEngine;
using System.Collections;

public class IdleStateBuildingCircle : AliveStateBuildingCircle {

	public IdleStateBuildingCircle(GameObject newGoBuildingCircle)
    {
        goBuildingCircle = newGoBuildingCircle;
    }
	
	public override void playAnim()
	{
		//Debug.Log("Bat " + goBuildingCircle.GetComponent<BuildingCircle>().getId() + " : STATE IDLE");
	}
	
	public override void checkOtherState()
	{
		BuildingCircle prod = goBuildingCircle.GetComponent<BuildingCircle>() ;
		//if(prod.spawn[prod.sTop] && prod.spawn[prod.sBot] && prod.spawn[prod.sLeft] && prod.spawn[prod.sRight]) prod.setCurrentState(prod.STATE_IDLE);
		if(prod.getNbSupport() >= prod.getNbSupportMax()) prod.setCurrentState(prod.STATE_IDLE);
		else 
		{
			//Debug.Log("Bat " + goBuildingCircle.GetComponent<BuildingCircle>().getId() + " is gonna prod again");
			prod.setCurrentState(prod.STATE_PROD);
		}
	}
	
	public override void prod()
	{
	}
}
