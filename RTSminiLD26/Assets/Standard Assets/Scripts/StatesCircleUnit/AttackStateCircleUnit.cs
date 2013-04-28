using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackStateCircleUnit : RightClickableStateCircleUnit
{

    public AttackStateCircleUnit(GameObject newGoCircleUnit)
    {
        goCircleUnit = newGoCircleUnit;
    }

    public override void playAnim()
    {
        Debug.Log("CircleUnit " + goCircleUnit.GetComponent<CircleUnits>().getId() + " is ATTACK");
        //TODO
    }

    public override void checkNewState()
    {
        CircleUnits unit = goCircleUnit.GetComponent<CircleUnits>();
        List<GameObject> enemies = unit.getProximityEnemies();
        if (enemies.Count == 0) unit.setCurrentState(unit.STATE_IDLE);
    }

    public override void attack()
    {

    }
}
