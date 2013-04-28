using UnityEngine;
using System.Collections;

public class PolygonUnits : Units {

    protected StatePolygonUnit STATE_BIRTH;
    protected StatePolygonUnit STATE_IDLE;
    protected StatePolygonUnit STATE_DEATH;
    protected StatePolygonUnit STATE_ATTACK;
    protected StatePolygonUnit STATE_GOINGTO;
    private StatePolygonUnit currentState;

	// Use this for initialization
	public override void Start () {

        STATE_BIRTH = new BirthStatePolygonUnit(gameObject);
        STATE_IDLE = new IdleStatePolygonUnit(gameObject);
        STATE_DEATH = new DeathStatePolygonUnit(gameObject);
        STATE_ATTACK = new AttackStatePolygonUnit(gameObject);
        STATE_GOINGTO = new GoingToStatePolygonUnit(gameObject);
        currentState = STATE_BIRTH;
        base.Start();
	
	}
	
	// Update is called once per frame
	public override void Update () {

        base.Update();
	
	}
}
