using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BirthStateCircleUnit : StateCircleUnit
{

    public BirthStateCircleUnit(GameObject newGoCircleUnit)
    {
        goCircleUnit = newGoCircleUnit;
    }

    public override void playAnim()
    {
        //Debug.Log("CircleUnit " + goCircleUnit.GetComponent<CircleUnits>().getId() + " is just BIRTH");
        //TODO
    }

    public override void playSound()
    {
        CircleUnits unit = goCircleUnit.GetComponent<CircleUnits>();
        unit.audio.clip=unit.audioPop;
        unit.audio.Play();
    }

    public override void checkNewState()
    {
        CircleUnits unit = goCircleUnit.GetComponent<CircleUnits>();
        List<GameObject> prods = unit.getProximityProds();
        int prodsCount = prods.Count ;
        if (prodsCount > 0)
        {
            bool findSupportNeeded = false;
            int countSupport = 0;
            while (!findSupportNeeded && countSupport < prodsCount)
            {
                //teste si il reste de la place autour d'un batiment de prod
                BuildingCircle prod = prods[countSupport].GetComponent<BuildingCircle>();
                if (prod.getNbSupport() < prod.getNbSupportMax())
                {
                    findSupportNeeded = unit.suscribeSupport(prods[countSupport]);
                   // Debug.Log("CircleUnit " + goCircleUnit.GetComponent<CircleUnits>().getId() + " should PROD");
                    unit.setCurrentState(unit.STATE_PROD);
                }
                countSupport++;
            }
            if (!findSupportNeeded) unit.setCurrentState(unit.STATE_IDLE);
        }
        else unit.setCurrentState(unit.STATE_IDLE);
    }
}
