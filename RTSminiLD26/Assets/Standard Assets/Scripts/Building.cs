using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

    public GameObject prefabUnit; 
    public int team; // 1 pour IA 2 pour le joueur
    protected float delayBetweenProd;
    protected float lastProdTime;
    protected int countUnits;
    protected GameObject lastUnit;
    protected Environnement env;

    public int getTeam()
    {
        return team;
    }

    public abstract void death();

	// Use this for initialization
	public virtual void Start () {

        env = Environnement.getUniqueEnv();
        lastProdTime = Time.time;
        countUnits = 0;
	
	}
	
	// Update is called once per frame
	public virtual void Update () {
	
	}
}
