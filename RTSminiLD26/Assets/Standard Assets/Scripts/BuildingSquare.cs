using UnityEngine;
using System.Collections;

public class BuildingSquare : Building {

    public void death()
    {
        Debug.Log("Death Square");
    }

	// Use this for initialization
	public override void Start () {

        base.Start();
        delayBetweenProd = 3;
	
	}
	
	// Update is called once per frame
	public override void Update () {

        base.Update();
	
	}
}
