using UnityEngine;
using System.Collections;

public class ProdStateCircleUnit : RightClickableStateCircleUnit
{

    public ProdStateCircleUnit(GameObject newGoCircleUnit)
    {
        goCircleUnit = newGoCircleUnit;
    }

    public override void playAnim()
    {
        Debug.Log("CircleUnit " + goCircleUnit.GetComponent<CircleUnits>().getId() + " is in PROD");
        //TODO
    }

    public override void checkOtherState()
    {
        CircleUnits unit = goCircleUnit.GetComponent<CircleUnits>();
        //si le bâtiment de production n'existe plus on passe en idle
        if (unit.getSupporting() == null) unit.setCurrentState(unit.STATE_IDLE);
    }
}
