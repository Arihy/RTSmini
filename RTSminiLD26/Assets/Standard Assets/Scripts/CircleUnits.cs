using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CircleUnits : Units
{
    public AudioClip audioPop;
    public AudioClip audioAttack;
   
    private GameObject supporting;

    public StateCircleUnit STATE_BIRTH;
    public StateCircleUnit STATE_IDLE;
    public StateCircleUnit STATE_DEATH;
    public StateCircleUnit STATE_PROD;
    public StateCircleUnit STATE_ATTACK;
    public StateCircleUnit STATE_GOINGTO;
	public StateCircleUnit STATE_TRIANGLEPROD;

    private StateCircleUnit lastState;
    private StateCircleUnit currentState;

    public GameObject getSupporting()
    {
        return supporting;
    }

    //called by production building when he dies
    public void signalProdDeath()
    {
        supporting = null;
    }

    //returns true if subscription is done
    public bool suscribeSupport(GameObject batProds)
    {
        if (supporting != null) return false; //on ne peut pas supporter ailleurs si on supporte déjà
        if (batProds.GetComponent<BuildingCircle>().addSupport(gameObject))
        {
            supporting = batProds;
            return true;
        }
        return false;
    }

    //returns true if unsuscribtion is done
    public bool unsuscribeSupport(GameObject batProds)
    {
        if (batProds.GetComponent<BuildingCircle>().removeSupport(gameObject))
        {
            supporting = null;
            return true;
        }
        return false;
    }

    public void setCurrentState(StateCircleUnit newState)
    {
        currentState = newState;
    }

    //Actions delegated to state
    private void playAnim()
    {
        currentState.playAnim();
    }

    private void playSound()
    {
        currentState.playSound();
    }

    private void checkNewState()
    {
        currentState.checkNewState();
    }

    private void attack()
    {
        currentState.attack();
    }

    public void move()
    {
        currentState.move();
    }
    //play sound

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        STATE_BIRTH = new BirthStateCircleUnit(gameObject);
        STATE_IDLE = new IdleStateCircleUnit(gameObject);
        STATE_DEATH = new DeathStateCircleUnit(gameObject);
        STATE_PROD = new ProdStateCircleUnit(gameObject);
        STATE_ATTACK = new AttackStateCircleUnit(gameObject);
        STATE_GOINGTO = new GoingToStateCircleUnit(gameObject);
		STATE_TRIANGLEPROD = new TriangleProdStateCircleUnit(gameObject);
        currentState = STATE_BIRTH;
        env = Environnement.getUniqueEnv();
        distancePercept = 30.0f;
        distanceAttack = 0.05f;//seems to be useless ... something messy somewhere
        setInitialEnergy(200.0f);
        attackStrength = 2.0f;
        attackFrequency = 240;
        speed = 30.0f;
        destination = Vector3.zero;
		initialVectorScale = gameObject.transform.localScale ;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        playSound();
        playAnim();
        attack();
        move();
        checkNewState();
    }
}