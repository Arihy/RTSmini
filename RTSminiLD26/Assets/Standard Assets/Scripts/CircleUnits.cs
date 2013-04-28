using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CircleUnits : Units
{
   
    private GameObject supporting;

    public bool suscribeSupport(GameObject batProds)
    {
        if (supporting != null) return false; //on ne peut pas supporter ailleurs si on supporte déjà
        if (batProds.GetComponent<BuildingCircle>().addSupport(gameObject))
        {
            supporting = batProds;
            return true;
        }
        return false;
    }

    public bool unsuscribeSupport(GameObject batProds)
    {
        if (batProds.GetComponent<BuildingCircle>().removeSupport(gameObject))
        {
            supporting = null;
            return true;
        }
        return false;
    }

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        env = Environnement.getUniqueEnv();
        distancePercept = 15.0f;
        energy = 10.0f;
        Debug.Log("start : " + team);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        Debug.Log("update : " + team);
        suscribeSupport(getProximityProds()[0]);
        if (supporting != null) Debug.Log(getId() + "supporting CC de la team : " + supporting.GetComponent<BuildingCircle>().getTeam());
        else Debug.Log(getId() + " not supporting !!!");
    }
}