using UnityEngine;
using System.Collections;

public class DeplacementCamera : MonoBehaviour {

	// Use this for initialization
    private float speed = 10.0f;
    private float translateX;
    private float translateY;
    private Transform thisTransform;
	void Start () {
        thisTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {

        translateX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        translateY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        thisTransform.Translate(translateX,translateY,0);
	
	}
}
