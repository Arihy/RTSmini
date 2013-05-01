using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class StateCircleUnit {
    protected GameObject goCircleUnit;

    public StateCircleUnit()
    {
    }

    public StateCircleUnit(GameObject newGoCircleUnit)
    {
        goCircleUnit = newGoCircleUnit;
    }

    public abstract void playAnim();
    public virtual void playSound() { }
    public abstract void checkNewState();
	public virtual void produceTriangle(){}
    public virtual void move() { }
    public virtual void attack(){ }
}
