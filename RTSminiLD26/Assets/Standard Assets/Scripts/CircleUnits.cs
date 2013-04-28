using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CircleUnits : Units
{
    public int team;

    private Environnement env;
    private float distancePercept = 15.0f;
    private Vector3 destination;
    private float energy;
    private GameObject supporting;

    public Environnement getEnv()
    {
        return env;
    }

    public int getTeam()
    {
        return team;
    }

    public void setTeam(int newTeam)
    {
        team = newTeam;
    }

    public float getDistancePercept()
    {
        return distancePercept;
    }

    public List<GameObject> getProximityEnemies()
    {
        return env.computeProximityEnemies(gameObject);
    }

    public List<GameObject> getProximityProds()
    {
        return env.computeProxymityProds(gameObject);
    }

    public void goTo(Vector3 dest)
    {
        destination = dest;

    }

    public float getEnergy()
    {
        return energy;
    }

    public bool mustDie()
    {
        if (energy <= 0) return true;
        return false;
    }

    public void reduceEnergy(float dmg)
    {
        energy = energy - dmg;
    }

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
        Debug.Log("start : " + team);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        Debug.Log("update : " + team);
    }
}
