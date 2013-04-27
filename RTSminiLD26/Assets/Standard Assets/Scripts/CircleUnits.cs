using UnityEngine;
using System.Collections;

public class CircleUnits : MonoBehaviour {
    public int team;

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
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("update : " + team);
	}
}
