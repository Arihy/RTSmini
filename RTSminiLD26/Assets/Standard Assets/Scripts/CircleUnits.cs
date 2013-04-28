using UnityEngine;
using System.Collections;

public class CircleUnits : Units {
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
	public override void Start () {
        base.Start();
        Debug.Log("start : " + team);
	}
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
        Debug.Log("update : " + team);
	}
}
