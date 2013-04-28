using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingCircle : MonoBehaviour
{

    public int team; // 1 pour IA 2 pour le joueur
    private float delayBetweenProd;
    private float lastProdTime;
    public GameObject prefabUnit;
    private int countUnits;
    private GameObject lastUnit;
    private Environnement env;
    private int supportMax;
    private int countSupport = 0;
    private List<GameObject> support = new List<GameObject>();
    
    //doit être appelé à la mort du bâtiment pour passer toutes les units en support à l'état idle
    public void death()
    {
        foreach (GameObject go in support)
        {
            go.GetComponent<CircleUnits>().signalProdDeath();
        }
    }

    public int getTeam()
    {
        return team;
    }

    public int getNbSupportMax()
    {
        return supportMax;
    }

    public int getNbSupport()
    {
        return countSupport;
    }

    public List<GameObject> getSupport()
    {
        return support;
    }

    public bool addSupport(GameObject go)
    {
        if (countSupport < supportMax && !support.Contains(go))
        {
            support.Add(go);
            countSupport++;
            return true;
        }
        return false;
    }

    public bool removeSupport(GameObject go)
    {
        if (countSupport > 0 && support.Contains(go))
        {
            support.Remove(go);
            countSupport--;
            return true;
        }
        return false;
    }

    // Use this for initialization
    void Start()
    {
        delayBetweenProd = 2;
        lastProdTime = Time.time;
        countUnits = 0;
        env = Environnement.getUniqueEnv();
        //enregistremet du batiment auprès de l'environnement
        env.addProd(gameObject);
        supportMax = 2;
    }

    // Update is called once per frame
    void Update()
    {
        float now = Time.time;
        if (countUnits < 3)
        {
            if (now - lastProdTime < delayBetweenProd)
            {
                //play animation between prod
            }
            else
            {
                //play animation prod
                //créer une unité - prefab CirlcleUnits
                Vector3 position = transform.position + transform.localScale / 2 + prefabUnit.transform.localScale / 2 + countUnits * (transform.localScale / 2 + prefabUnit.transform.localScale / 2);
                lastUnit = (GameObject)Instantiate(prefabUnit, position, Quaternion.identity);
                //il faut définir la team de l'unité
                lastUnit.GetComponent<CircleUnits>().setTeam(team);
                Environnement env = Environnement.getUniqueEnv();
                //on ajoute l'unité à l'environnement
                env.addUnit(lastUnit);
                lastProdTime = now;
                countUnits++;
            }
        }
    }
}
