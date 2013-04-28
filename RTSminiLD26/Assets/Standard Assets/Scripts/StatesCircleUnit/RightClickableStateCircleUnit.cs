using UnityEngine;
using System.Collections;

public abstract class RightClickableStateCircleUnit : ActiveStateCircleUnit
{
    public override void checkOtherState()
    {
        CircleUnits unit = goCircleUnit.GetComponent<CircleUnits>();
        if (unit.getDestination() != Vector3.zero) unit.setCurrentState(unit.STATE_GOINGTO);
        else checkOtherState2();
    }

    public abstract void checkOtherState2();
}
