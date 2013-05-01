using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DieStateBuildingCircle : StateBuildingCircle {
	
	public DieStateBuildingCircle(GameObject newGoBuildingCircle)
    {
        goBuildingCircle = newGoBuildingCircle;
    }

    public override void playAnim()
	{
		//Debug.Log("Bat " + goBuildingCircle.GetComponent<BuildingCircle>().getId() + " : STATE DIE");
	}
	
    public override void checkNewState()
	{
	}
	
	public override void prod()
	{
	}
	
	//doit être appelé à la mort du bâtiment pour passer toutes les units en support à l'état idle
	public override void die()
	{
		BuildingCircle prod = goBuildingCircle.GetComponent<BuildingCircle>();
		List<GameObject> support = prod.getSupport();
		foreach (GameObject go in support)
        {
            go.GetComponent<CircleUnits>().signalProdDeath();
        }
		//destroy
		//Debug.Log("Prod " + prod.getId() + " sends Destroy!!!!");
        prod.destroy();
	}
}
