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
       // Debug.Log("CircleUnit " + goCircleUnit.GetComponent<CircleUnits>().getId() + " is IDLE");
        //TODO
    }

    public override void checkOtherState2()
    {
        CircleUnits unit = goCircleUnit.GetComponent<CircleUnits>();
        List<GameObject> enemies = unit.getProximityEnemies();
        if (enemies.Count > 0) unit.setCurrentState(unit.STATE_ATTACK);
    }
}
