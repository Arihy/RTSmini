using UnityEngine;
using System.Collections;

public class BuildingTriangle : Building {
	
	private int countSphere;
	
	public GameObject spawnPoint;
	
	public GameObject prefabTriangleUnit;
	
	public StateTriangleBuilding STATE_PROD;
	public StateTriangleBuilding STATE_IDLE;
	public StateTriangleBuilding STATE_DIE;
	
	private StateTriangleBuilding currentState;
	
	public void setCurrentState(StateTriangleBuilding newState)
	{
		currentState = newState;
	}
	
	public void createUnit()
	{
		Debug.Log("create unit !!!");
		if(countSphere > 1)
		{
			if(spawnPoint.GetComponent<SpawnManager>().getAvailability())
			{
				Instantiate(prefabTriangleUnit, spawnPoint.transform.position, Quaternion.identity);
				countSphere = countSphere - 2 ;
			}
			Debug.Log(" Prod un triangle !!!");
		}
	}
	
	private void playAnim()
	{
		currentState.playAnim();
	}
	
	private void prod()
	{
		currentState.prod();
	}
	
	private void die()
	{
		currentState.die ();
	}
	
	private void checkNewState()
	{
		currentState.checkNewState();
	}
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
		playAnim();
		prod();
		die();
		checkNewState();
	}
	
	public void suscribe()
	{
		countSphere ++ ;
	}
	
	public int getCountSphere()
	{
		return countSphere;
	}
	
	// Use this for initialization
	public override void Start () {
        base.Start();
		STATE_PROD = new ProdStateTriangleBuilding(gameObject);
		STATE_IDLE = new IdleStateTriangleBuilding(gameObject);
		STATE_DIE = new DieStateTriangleBuilding(gameObject);
		currentState = STATE_IDLE;
		env = Environnement.getUniqueEnv();
        //enregistremet du batiment auprès de l'environnement
        env.addProdTriangle(gameObject);
		countSphere = 0;
		setInitialEnergy(10.0f);
	}
}
