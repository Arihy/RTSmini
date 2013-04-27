using UnityEngine;
using System.Collections;

public class CircleUnits : MonoBehaviour {
    private int team;
    private Environnement env;

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
	// Use this for initialization
	void Start () {
        Debug.Log("start : " + team);
        env = Environnement.getUniqueEnv();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("update : " + team);
	}
}
