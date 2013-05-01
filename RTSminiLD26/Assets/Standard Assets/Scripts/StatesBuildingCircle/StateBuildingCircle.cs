using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class StateBuildingCircle
{
    protected GameObject goBuildingCircle;

    public StateBuildingCircle()
    {
    }

    public StateBuildingCircle(GameObject newGoBuildingCircle)
    {
        goBuildingCircle = newGoBuildingCircle;
    }

    public abstract void playAnim();
    public abstract void checkNewState();
	public abstract void die();
    public abstract void prod();
}

