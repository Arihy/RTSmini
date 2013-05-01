using UnityEngine;
using System.Collections;

public class ProdStateTriangleBuilding : AliveStateTriangleBuilding {
	
	public ProdStateTriangleBuilding(GameObject NewGoTriangleBuilding)
	{
		goTriangleBuilding = NewGoTriangleBuilding;
	}
	
	public override void playAnim()
	{
		Debug.Log("Bat Triangle " + goTriangleBuilding.GetComponent<BuildingTriangle>().getId() + " : STATE PROD");
	}
    public override void checkOtherState()
	{
		BuildingTriangle triangleProd = goTriangleBuilding.GetComponent<BuildingTriangle>();
		if(triangleProd.getCountSphere() >= 2) triangleProd.setCurrentState(triangleProd.STATE_PROD);
		else triangleProd.setCurrentState(triangleProd.STATE_IDLE);
	}
	public override void die() { }
    public override void prod()
	{
		BuildingTriangle triangleProd = goTriangleBuilding.GetComponent<BuildingTriangle>();
		triangleProd.createUnit();
	}
}
