using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Environnement
{

    private List<GameObject> iaUnits = new List<GameObject>();
    private List<GameObject> playerUnits = new List<GameObject>();
    private List<GameObject> iaProds = new List<GameObject>();
    private List<GameObject> playerProds = new List<GameObject>();

    private int currentId;

    private static Environnement uniqueEnv;

    public static Environnement getUniqueEnv()
    {
        if (uniqueEnv == null)
        {
            uniqueEnv = new Environnement();
            uniqueEnv.currentId = 0;
        }
        return uniqueEnv;
    }

    public void addUnit(GameObject gaunit)
    {
        int teamAgent = gaunit.GetComponent<CircleUnits>().getTeam();
        if (teamAgent == 1)
        {
            iaUnits.Add(gaunit);
        }
        else
        {
            playerUnits.Add(gaunit);
        }
        currentId++;
        gaunit.GetComponent<Units>().setId(currentId);
    }

    public void removeUnit(GameObject gaunit)
    {
        int teamAgent = gaunit.GetComponent<CircleUnits>().getTeam();
        if (teamAgent == 1)
        {
            iaUnits.Remove(gaunit);
        }
        else
        {
            playerUnits.Remove(gaunit);
        }
    }

    public List<GameObject> getIaUnits()
    {
        return iaUnits;
    }

    public List<GameObject> getPlayerunits()
    {
        return playerUnits;
    }

    public List<GameObject> computeProximityEnemies(GameObject gounit)
    {
        Vector3 positionUnit = gounit.transform.position;

        float distancePerceptUnit = gounit.GetComponent<CircleUnits>().getDistancePercept();

        int teamUnit = gounit.GetComponent<CircleUnits>().getTeam();

        List<GameObject> enemies;
        List<GameObject> proximitiesEnemies = new List<GameObject>();
        if (teamUnit == 1)
        {
            enemies = playerUnits;
        }
        else
        {
            enemies = iaUnits;
        }

        foreach (GameObject go in enemies)
        {
            Vector3 positionA = go.transform.position;
            float distance = Vector3.Distance(positionA, positionUnit);
            if (distance <= distancePerceptUnit) //TODO trier du plus proche au plus éloigné
            {
                proximitiesEnemies.Add(go);
            }
        }
        return proximitiesEnemies;
    }

    public void addProd(GameObject gabat)
    {
        int teamBat = gabat.GetComponent<BuildingCircle>().getTeam();
        if (teamBat == 1)
        {
            iaProds.Add(gabat);
        }
        else
        {
            playerProds.Add(gabat);
        }
    }

    public List<GameObject> getIaProds()
    {
        return iaProds;
    }

    public List<GameObject> getPlayerprods()
    {
        return playerProds;
    }

    public List<GameObject> computeProxymityProds(GameObject gounit)
    {
        Vector3 positionUnit = gounit.transform.position;

        float distancePerceptUnit = gounit.GetComponent<CircleUnits>().getDistancePercept();

        int teamUnit = gounit.GetComponent<CircleUnits>().getTeam();

        List<GameObject> batProds;
        List<GameObject> proximitiesProds = new List<GameObject>();
        if (teamUnit == 1)
        {
            batProds = iaProds;
        }
        else
        {
            batProds = playerProds;
        }

        foreach (GameObject go in batProds)
        {
            Vector3 positionA = go.transform.position;
            float distance = Vector3.Distance(positionA, positionUnit);
            if (distance <= distancePerceptUnit)
            {
                proximitiesProds.Add(go);
            }
        }
        return proximitiesProds;
    }
}