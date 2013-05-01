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
        //Debug.Log("CircleUnit " + goCircleUnit.GetComponent<CircleUnits>().getId() + " is ATTACK");
        //TODO
    }

    public override void checkOtherState2()
    {
        CircleUnits unit = goCircleUnit.GetComponent<CircleUnits>();
        List<GameObject> enemies = unit.getProximityEnemies();
		//Debug.Log("Enemies : " + enemies.Count);
        if (enemies.Count == 0) unit.setCurrentState(unit.STATE_IDLE);
    }

    public override void attack()
    {
        CircleUnits unit = goCircleUnit.GetComponent<CircleUnits>();
        List<GameObject> enemies = unit.getProximityEnemies();
        if (enemies.Count > 0)
        {
            if(Time.frameCount - unit.getNbFrameSinceLastShot() >= unit.getAttackFrequency())//vérifier que l'on peut attaquer en terme de fréquence
            {
                //calcul de la distance avec l'ennemi le plus proche
                Vector3 positionA = goCircleUnit.transform.position;
                Vector3 positionUnit = enemies[0].transform.position;
                float distance = Vector3.Distance(positionA, positionUnit);
                if (unit.getDistanceAttack() <= distance)
                {
                    //attacks !!!!
          //          Debug.Log("CircleUnit " + goCircleUnit.GetComponent<CircleUnits>().getId() + " attacks : " + enemies[0].GetComponent<Units>().getId());
                    enemies[0].GetComponent<Units>().reduceEnergy(unit.getAttackStrength());
                }
            }
        }
    }
}
