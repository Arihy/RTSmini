using UnityEngine;
using System.Collections;

public class DeathStateCircleUnit : StateCircleUnit
{

    public DeathStateCircleUnit(GameObject newGoCircleUnit)
    {
        goCircleUnit = newGoCircleUnit;
    }

    public override void playAnim()
    {
        Debug.Log("CircleUnit " + goCircleUnit.GetComponent<CircleUnits>().getId() + " is just DEAD");
        //TODO
    }

    public override void checkNewState()
    {
        Debug.Log("CircleUnit " + goCircleUnit.GetComponent<CircleUnits>().getId() + " no new state i'm dead you know!!! but i still have few last things to do ....");
        CircleUnits unit = goCircleUnit.GetComponent<CircleUnits>();
        //se retirer de tout support de prod
        GameObject supporting =  unit.getSupporting();
        if (supporting != null) supporting.GetComponent<BuildingCircle>().removeSupport(goCircleUnit);
        //se retirer de l'environnement
        unit.getEnv().removeUnit(goCircleUnit);
        //destroy
        Debug.Log("CircleUnit " + goCircleUnit.GetComponent<CircleUnits>().getId() + " sends Destroy!!!!");
        goCircleUnit.GetComponent<CircleUnits>().destroy();
    }
}
