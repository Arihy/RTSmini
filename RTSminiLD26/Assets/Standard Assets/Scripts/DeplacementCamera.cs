using UnityEngine;
using System.Collections;

public class DeplacementCamera : MonoBehaviour {

	// Use this for initialization
    private float speed = 40.0f;
    private float translateX;
    private float translateZ;
    private Transform thisTransform;
	
	void Start () {
        thisTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {

        translateX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        translateZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        thisTransform.Translate(translateX, 0, translateZ);
	
	}
}
