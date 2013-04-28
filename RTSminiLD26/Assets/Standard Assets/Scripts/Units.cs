using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Units : MonoBehaviour {

    private int id;

    public bool selected = false;
    public int team;

    protected Environnement env;
    protected float distancePercept;
    protected float distanceAttack;
    protected float energy;
    protected Vector3 destination;
    protected float attackStrength;
    protected int attackFrequency;
    private int nbFrameSinceLastShot;

    public int getId()
    {
        return id;
    }

    public void setId(int newId)
    {
        id = newId;
    }

    public Environnement getEnv()
    {
        return env;
    }


    public int getNbFrameSinceLastShot()
    {
        return nbFrameSinceLastShot;
    }

    public void setNbFrameSinceLastShot(int newNbFrame)
    {
        nbFrameSinceLastShot = newNbFrame;
    }

    public float getDistanceAttack()
    {
        return distanceAttack;
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

    public List<GameObject> getProximityProds()
    {
        return env.computeProxymityProds(gameObject);
    }

    public void goTo(Vector3 dest)
    {
        destination = dest;

    }

    public float getEnergy()
    {
        return energy;
    }

    public bool mustDie()
    {
        if (energy <= 0) return true;
        return false;
    }

    public void reduceEnergy(float dmg)
    {
        energy = energy - dmg;
    }

    public void destroy()
    {
        Destroy(gameObject);
    }

    //Start is called to intialize the instance
    public virtual void Start()
    {
        Debug.Log("start Units");
        nbFrameSinceLastShot = 0;
    }
	
	// Update is called once per frame
	public virtual void Update () 
    {
        if (renderer.isVisible && Input.GetMouseButton(0))
        {
            Vector3 camPos = Camera.mainCamera.WorldToScreenPoint(transform.position);
            camPos.y = BoxSelection.InvertMouseY(camPos.y);
            selected = BoxSelection.selection.Contains(camPos);
        }
        if (selected)
        {
            //must change state
            renderer.material.color = Color.red;
        }
        else //must change state
            renderer.material.color = Color.white;
	
	}
}
