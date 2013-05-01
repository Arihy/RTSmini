using UnityEngine;
using System.Collections;

public class MouseSpriteMove : MonoBehaviour {
	private float timeToDestroy = 0.2f;
	private float timeClick;
	// Use this for initialization
	void Start () {
		timeClick = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - timeClick > timeToDestroy)
			Destroy(gameObject);
	}
}
