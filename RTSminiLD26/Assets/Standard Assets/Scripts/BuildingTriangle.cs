using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingTriangle : Building {


    public void death()
    {
        Debug.Log("Death Triangle");
    }

	// Use this for initialization
	public override void Start () {

        base.Start();
        delayBetweenProd = 1;
	
	}
	
	// Update is called once per frame
	public override void Update () {

        base.Update();
	
	}
}
