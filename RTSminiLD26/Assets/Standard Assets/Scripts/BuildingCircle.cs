using UnityEngine;
using System.Collections;

public class BuildingCircle : MonoBehaviour {

    public int team;
    private float delayBetweenProd;
    private float lastProdTime;
    public GameObject prefabUnit;
    private int countUnits;
    private GameObject lastUnit;

	// Use this for initialization
	void Start () {
        delayBetweenProd = 2;
        lastProdTime = Time.time;
        countUnits = 0;
	}
	
	// Update is called once per frame
	void Update () {
        float now = Time.time;
        if(countUnits < 3)
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
                env.addUnit(lastUnit);
                lastProdTime = now;
                countUnits++;
            }
        }
	}
}
