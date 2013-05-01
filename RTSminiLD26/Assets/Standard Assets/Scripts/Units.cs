using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Units : MonoBehaviour {
	public GameObject mouseSpriteMove;
    private int id;

    public bool selected = false;
    public int team;
    protected float speed;
    protected float stopDistanceOffset = 3.2f;

    protected Environnement env;
    protected float distancePercept;
    protected float distanceAttack;
    private float energy;
	private float energyMax;
    protected Vector3 destination;
    protected float attackStrength;
    protected int attackFrequency;
    private int nbFrameSinceLastShot;
	protected Vector3 initialVectorScale;

    public float floorOffset = 1;
    private Vector3 moveToDestination = Vector3.zero;

    public int getId()
    {
        return id;
    }

    public void setId(int newId)
    {
        id = newId;
    }
	
	protected void setInitialEnergy(float newenergy)
	{
		energy = newenergy;
		energyMax = newenergy;
	}
	
	public float getEnergyMax()
	{
		return energyMax;
	}
	
    public float getSpeed()
    {
        return speed;
    }

    public float getStopDistanceOffset()
    {
        return stopDistanceOffset;
    }

    public Vector3 getDestination()
    {
        return destination;
    }

    public void setDestination(Vector3 dest)
    {
        destination = dest ;
    }

    public Environnement getEnv()
    {
        return env;
    }

    public float getAttackStrength()
    {
        return attackStrength;
    }

    public int getNbFrameSinceLastShot()
    {
        return nbFrameSinceLastShot;
    }

    public void setNbFrameSinceLastShot(int newNbFrame)
    {
        nbFrameSinceLastShot = newNbFrame;
    }

    public int getAttackFrequency()
    {
        return attackFrequency;
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
	
	public List<GameObject> getProximityTriangleProds()
	{
		return env.computeProxymityTriangleProds(gameObject);
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
		//se retirer de l'environnement
        env.removeUnit(gameObject);
        Destroy(gameObject);
    }
	
	protected void computeUnityScale()
	{
		//calcul du ratio
		float ratio = energy / energyMax ;
		//application du ratio à la taille
		if(ratio > 0.40f) gameObject.transform.localScale = ratio * initialVectorScale;
	}

    //Start is called to intialize the instance
    public virtual void Start()
    {
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

            if (selected)
            {
                //must change state
                foreach(Transform child in transform)
				{
					if(child.name == "Sphere")
						child.renderer.enabled = true;
				}
            }
            else //must change state
			{
				foreach(Transform child in transform)
				{
					if(child.name == "Sphere")
						child.renderer.enabled = false;
				}
			}
        }

        if (selected && Input.GetMouseButtonUp(1))
        {
           
            //Récupérer la position du clic droit
            //Vector3 dest = BoxSelection.getDestination();
            RaycastHit hit;
            Ray r = Camera.mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(r, out hit))
            {
                Vector3 dest = hit.point;
                Debug.Log("destination : " + dest);
				
				Vector3 newPosition = dest;
				newPosition.y = 1;
				Instantiate(mouseSpriteMove, newPosition, Quaternion.identity);

                if (dest != Vector3.zero)
                {

                    moveToDestination = dest;
                    moveToDestination.y += floorOffset;
                }
                //transmettre la position du clic à l'unit
                destination = dest;
            }
            
        }
		computeUnityScale();
	}

}
