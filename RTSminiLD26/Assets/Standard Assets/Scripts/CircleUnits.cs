using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CircleUnits : Units
{
   
    private GameObject supporting;

    public StateCircleUnit STATE_BIRTH;
    public StateCircleUnit STATE_IDLE;
    public StateCircleUnit STATE_DEATH;
    public StateCircleUnit STATE_PROD;
    public StateCircleUnit STATE_ATTACK;

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

    private void checkNewState()
    {
        currentState.checkNewState();
    }

    private void attack()
    {
        currentState.attack();
    }

    //move
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
        currentState = STATE_BIRTH;
        env = Environnement.getUniqueEnv();
        distancePercept = 15.0f;
        energy = 10.0f;
        attackStrength = 2.0f;
        attackFrequency = 10;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        playAnim();
        attack();
        checkNewState();
       
    }
}