using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CircleUnits : Units {
    public int team;

    private Environnement env;
    private float distancePercept = 15.0f;

    public Environnement getEnv()
    {
        return env;
    }

    public int getTeam()
    {
        return team;
    }

    public void setTeam(int newTeam)
    {
        team = newTeam;
    }

    public float getDistancePercept()
    {
        return distancePercept;
    }

    public List<GameObject> getProximityEnemies()
    {
        return env.computeProximityEnemies(gameObject);
    }

	// Use this for initialization
	public override void Start () {
        base.Start();
        env = Environnement.getUniqueEnv();
        Debug.Log("start : " + team);
	}
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
        Debug.Log("update : " + team);
    }
}
