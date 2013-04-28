using UnityEngine;
using System.Collections;

public class GoingToStateCircleUnit : ActiveStateCircleUnit
{

    public GoingToStateCircleUnit(GameObject newGoCircleUnit)
    {
        goCircleUnit = newGoCircleUnit;
    }

    public override void playAnim()
    {
        Debug.Log("CircleUnit " + goCircleUnit.GetComponent<CircleUnits>().getId() + " going to : " + goCircleUnit.GetComponent<CircleUnits>().getDestination());
        //TODO
    }

    public override void move()
    {
        Debug.Log("move()");
        CircleUnits unit = goCircleUnit.GetComponent<CircleUnits>();
        if (unit.getDestination() != Vector3.zero && goCircleUnit.transform.position != unit.getDestination())
        {
            Vector3 direction = (unit.getDestination() - goCircleUnit.transform.position).normalized;
            direction.y = 0;
            goCircleUnit.transform.rigidbody.velocity = direction * unit.getSpeed();

            if (Vector3.Distance(goCircleUnit.transform.position, unit.getDestination()) < unit.getStopDistanceOffset())
            {
                unit.setDestination(Vector3.zero);
            }
        }
        else
        {
            Debug.Log("velocity zero");
            goCircleUnit.transform.rigidbody.velocity = Vector3.zero;
            unit.setDestination(Vector3.zero);
        }
    }

    public override void checkOtherState()
    {
        CircleUnits unit = goCircleUnit.GetComponent<CircleUnits>();
       // resteAparcourir ;//différence entre ou je suis et ou je dois aller
        if (Vector3.Distance(goCircleUnit.transform.position, unit.getDestination()) > unit.getStopDistanceOffset())
        {
            unit.setCurrentState(unit.STATE_GOINGTO);
        }
        else
        {
            unit.setDestination(Vector3.zero);
            unit.setCurrentState(unit.STATE_IDLE);
        }
    }
}
