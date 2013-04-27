using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CircleUnits : MonoBehaviour {
    private int team;
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
	void Start () {
        env = Environnement.getUniqueEnv();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
