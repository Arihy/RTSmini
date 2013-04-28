using UnityEngine;
using System.Collections;

public abstract class ActiveStateCircleUnit : StateCircleUnit
{
    public bool checkMustDie()
    {
        CircleUnits unit = goCircleUnit.GetComponent<CircleUnits>();
        if (unit.getEnergy() <= 0)
        {
            unit.setCurrentState(unit.STATE_DEATH);
            return true;
        }
        return false;
    }

    public override void checkNewState()
    {
        if (!checkMustDie()) checkOtherState();
    }

    public abstract void checkOtherState();
}
