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
            if (distance <= distancePerceptUnit)
            {
                proximitiesEnemies.Add(go);
            }
        }

        proximitiesEnemies = triDistance(proximitiesEnemies, gounit);
        return proximitiesEnemies;
    }

    //méthode servant à trier les gameobjects dans un tableau suivant leurs distances par 
    //rapport au gameobject de référence (le gameobject leplus proche en haut du tableau)
    public List<GameObject> triDistance(List<GameObject> tab, GameObject go0)
    {
        Vector3 position0 = go0.transform.position;
        int n = tab.Count;
        List<GameObject> tableau = new List<GameObject>();
        tableau = tab;

        //On prend les gameobjects du tableau deux à deux en partant du haut, on calcule 
        //leurs distances par rapport au gameobject goO, on compare les distances et on
        //permute les deux gameobjects ou non de façon à ce que le plus proche se retrouve 
        //le plus haut dans le tableau
        for (int i = 0; i <= n - 2; i++)
        {
            for (int j = i + 1; j <= n-1; j++)
            {
                var distancei = Vector3.Distance(position0, tableau[i].transform.position);
                var distancej = Vector3.Distance(position0, tableau[j].transform.position);

                if (distancei > distancej)
                    tableau = permute(i, j, tableau);
            }
        }
        //on renvoie le tableau trié
        return tableau;
    }

    //méthode servant à permuter deux gameobjects définis par leurs positions respectives i et j dans un tableau
    public List<GameObject> permute(int i, int j, List<GameObject> tab)
    {
        List<GameObject> tableau1 = new List<GameObject>();
        List<GameObject> tableau2 = new List<GameObject>();
        tableau1 = tab;
        int n = tableau1.Count;

        for (int b=0; b <= n - 1; b++)
        {
            if (b == i)
                tableau2[b] = tableau1[j];
            else if (b == j)
                tableau2[b] = tableau1[i];
            else
                tableau2[b] = tableau1[b];
        }

        return tableau2;
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