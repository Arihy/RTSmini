using UnityEngine;
using System.Collections;

public class GoingToStateCircleUnit : ActiveStateCircleUnit
{
	
	private bool arrived = false ;
	
    public GoingToStateCircleUnit(GameObject newGoCircleUnit)
    {
        goCircleUnit = newGoCircleUnit;
    }

    public override void playAnim()
    {
       // Debug.Log("CircleUnit " + goCircleUnit.GetComponent<CircleUnits>().getId() + " going to : " + goCircleUnit.GetComponent<CircleUnits>().getDestination());
        //TODO
    }

    public override void move()
    {
        //Debug.Log("move()");
        CircleUnits unit = goCircleUnit.GetComponent<CircleUnits>();
		//se retirer de tout support de prod
        GameObject supporting =  unit.getSupporting();
        if (supporting != null) unit.unsuscribeSupport(supporting);
        if (unit.getDestination() != Vector3.zero && goCircleUnit.transform.position != unit.getDestination())
        {
            Vector3 direction = (unit.getDestination() - goCircleUnit.transform.position).normalized;
            direction.y = 0;
            goCircleUnit.transform.rigidbody.velocity = direction * unit.getSpeed();
			
			//rotation sur y selon la vitesse de deplacement
			goCircleUnit.transform.Rotate(0, direction.magnitude * -40.0f, 0);

            if (Vector3.Distance(goCircleUnit.transform.position, unit.getDestination()) < unit.getStopDistanceOffset())
            {
                unit.setDestination(Vector3.zero);
				arrived = true ;
            }
        }
        else
        {
       //     Debug.Log("velocity zero");
            goCircleUnit.transform.rigidbody.velocity = Vector3.zero;
            unit.setDestination(Vector3.zero);
			arrived = true;
        }
    }

    public override void checkOtherState()
    {
        CircleUnits unit = goCircleUnit.GetComponent<CircleUnits>();
       // resteAparcourir ;//différence entre ou je suis et ou je dois aller
		//Debug.Log("check other state");
		//Debug.Log("distance : " + Vector3.Distance(goCircleUnit.transform.position, unit.getDestination()) + "distance offset : " + unit.getStopDistanceOffset());
        //if (Vector3.Distance(goCircleUnit.transform.position, unit.getDestination()) > unit.getStopDistanceOffset())
		if (!arrived)
      	{
		//	Debug.Log("set Current State : GOINGTO");
            unit.setCurrentState(unit.STATE_GOINGTO);
        }
        else
        {
		//	Debug.Log("set Current State : STATE_IDLE");
            unit.setDestination(Vector3.zero);
            unit.setCurrentState(unit.STATE_IDLE);
			arrived = false;
        }
    }
}
