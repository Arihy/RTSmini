using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {
	private bool isAvailable;
	
	public bool getAvailability()
	{
		return isAvailable;
	}
	
	// Use this for initialization
	void Start () {
		isAvailable = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		isAvailable = false;
	}
	
	void OnTriggerExit(Collider other)
	{
		isAvailable = true;
	}
}
