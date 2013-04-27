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
        Debug.Log("env will add unit");
        int teamAgent = gaunit.GetComponent<CircleUnits>().getTeam();
        if (teamAgent == 1)
        {
            iaUnits.Add(gaunit);
            Debug.Log("env added iaunit");
        }
        else
        {
            playerUnits.Add(gaunit);
            Debug.Log("env added playerunit");
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
}