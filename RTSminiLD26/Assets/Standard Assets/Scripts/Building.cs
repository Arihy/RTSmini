using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

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

	// Use this for initialization
	public virtual void Start () {


	
	}
	
	// Update is called once per frame
	public virtual void Update () {
	
	}
}
