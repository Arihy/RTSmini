using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingCircle : Building
{
    
    private int supportMax;
    private int countSupport = 0;
    private List<GameObject> support = new List<GameObject>();
    
    //doit �tre appel� � la mort du b�timent pour passer toutes les units en support � l'�tat idle
    public void death()
    {
        foreach (GameObject go in support)
        {
            go.GetComponent<CircleUnits>().signalProdDeath();
        }
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
    public override void Start()
    {
        base.Start();
        delayBetweenProd = 2;
       
        
        //enregistremet du batiment aupr�s de l'environnement
        env.addProd(gameObject);
        supportMax = 2;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
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
                //cr�er une unit� - prefab CirlcleUnits
                Vector3 position = transform.position + transform.localScale / 2 + prefabUnit.transform.localScale / 2 + countUnits * (transform.localScale / 2 + prefabUnit.transform.localScale / 2);
                lastUnit = (GameObject)Instantiate(prefabUnit, position, Quaternion.identity);
                //il faut d�finir la team de l'unit�
                lastUnit.GetComponent<CircleUnits>().setTeam(team);
                Environnement env = Environnement.getUniqueEnv();
                //on ajoute l'unit� � l'environnement
                env.addUnit(lastUnit);
                lastProdTime = now;
                countUnits++;
            }
        }
    }
}
