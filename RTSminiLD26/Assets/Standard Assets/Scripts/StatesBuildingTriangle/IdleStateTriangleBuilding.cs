using UnityEngine;
using System.Collections;

public class IdleStateTriangleBuilding : AliveStateTriangleBuilding {
	
	public IdleStateTriangleBuilding(GameObject NewGoTriangleBuilding)
	{
		goTriangleBuilding = NewGoTriangleBuilding;
	}
	
	public override void playAnim()
	{
		Debug.Log("Bat Triangle " + goTriangleBuilding.GetComponent<BuildingTriangle>().getId() + " : STATE IDLE");
	}
    public override void checkOtherState()
	{
		BuildingTriangle triangleProd = goTriangleBuilding.GetComponent<BuildingTriangle>();
		if(triangleProd.getCountSphere() >= 2) triangleProd.setCurrentState(triangleProd.STATE_PROD);
		else triangleProd.setCurrentState(triangleProd.STATE_IDLE);
	}
	public override void die() { }
    public override void prod() { }
}
