using UnityEngine;
using System.Collections;

public abstract class AliveStateBuildingCircle : StateBuildingCircle 
{

    public override void checkNewState()
	{
		BuildingCircle prod = goBuildingCircle.GetComponent<BuildingCircle>();
		if(prod.getEnergy() <= 0) prod.setCurrentState(prod.STATE_DIE);
		else checkOtherState();
	}
	
	public override void die()
	{
	}
	
	public abstract void checkOtherState();
	
}
