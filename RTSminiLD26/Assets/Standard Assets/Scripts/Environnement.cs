using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Environnement {

    private List<GameObject> iaUnits = new List<GameObject>();
    private List<GameObject> playerUnits = new List<GameObject>();
    private static Environnement uniqueEnv;

    public static Environnement getUniqueEnv()
    {
        if (uniqueEnv == null)
        {
            uniqueEnv = new Environnement();
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
            if (distance <= distancePerceptUnit)
            {
                proximitiesEnemies.Add(go);
            }
        }
        return proximitiesEnemies;
    }
}