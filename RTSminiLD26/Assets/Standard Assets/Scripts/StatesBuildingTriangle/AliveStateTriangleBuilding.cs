using UnityEngine;
using System.Collections;

public abstract class AliveStateTriangleBuilding : StateTriangleBuilding {

	public override void checkNewState()
	{
		BuildingTriangle prod = goTriangleBuilding.GetComponent<BuildingTriangle>();
		if(prod.getEnergy() <= 0) prod.setCurrentState(prod.STATE_DIE);
		else checkOtherState();
	}
	
	public override void die()
	{
	}
	
	public abstract void checkOtherState();
}
