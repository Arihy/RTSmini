using UnityEngine;
using System.Collections;

public class TriangleProdStateCircleUnit : StateCircleUnit {

	public TriangleProdStateCircleUnit(GameObject newGoCircleUnit)
    {
        goCircleUnit = newGoCircleUnit;
    }

    public override void playAnim()
	{
		//Debug.Log("CircleUnit " + goCircleUnit.GetComponent<CircleUnits>().getId() + " STATE PROD TRIANGLE");
	}
    public override void checkNewState()
	{
		CircleUnits unit = goCircleUnit.GetComponent<CircleUnits>();
		unit.setCurrentState(unit.STATE_DEATH);
	}
	public override void produceTriangle()
	{
	}
}
