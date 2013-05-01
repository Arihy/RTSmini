using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

    public int team; // 1 pour IA 2 pour le joueur 0 si non attribuée
    protected int delayBetweenProd;
    protected int countSinceLastProd;
    protected int countUnits;
    public GameObject lastUnit;
    protected Environnement env;
	private int id;
	private float energy;
	private float energyMax;
	
	public int getId()
	{
		return id;
	}
	
	public void incrementCountUnit()
	{
		countUnits++;
	}
	
	public int getDelayBetweenProd()
	{
		return delayBetweenProd;
	}
	
	public void setInitialEnergy(float newEnergy)
	{
		energy = newEnergy;
		energyMax = newEnergy;
	}
	
	public void reduceEnergy(float dmg)
    {
        energy = energy - dmg;
    }
	
	public float getEnergy()
	{
		return energy;
	}
	
	public void setId(int newId)
	{
		id = newId;
	}

    public int getTeam()
    {
        return team;
    }
	
	public Environnement getEnvironnement()
	{
		return env;
	}
	
	public void destroy()
    {
		//se retirer de l'environnement
		env.removeProd(gameObject);
        Destroy(gameObject);
    }

	// Use this for initialization
	public virtual void Start () {
		
	
	}
	
	// Update is called once per frame
	public virtual void Update () {
	
	}
}
