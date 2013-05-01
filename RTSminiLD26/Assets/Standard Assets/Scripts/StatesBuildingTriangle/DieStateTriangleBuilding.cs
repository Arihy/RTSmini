using UnityEngine;
using System.Collections;

public class DieStateTriangleBuilding : StateTriangleBuilding {
	
	public DieStateTriangleBuilding(GameObject newGoTriangleBuilding)
	{
		goTriangleBuilding = newGoTriangleBuilding;
	}
	
	public override void playAnim()
	{
		Debug.Log("Bat Triangle " + goTriangleBuilding.GetComponent<BuildingTriangle>().getId() + " : STATE DIE");
	}
    public override void checkNewState(){}
	public override void die() { }
    public override void prod() { }
}
