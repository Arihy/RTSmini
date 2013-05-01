using UnityEngine;
using System.Collections;

public abstract class StateTriangleBuilding{
	protected GameObject goTriangleBuilding;
	
	public StateTriangleBuilding()
	{
	}
	
	public StateTriangleBuilding(GameObject _goTriangleBuilding)
	{
		goTriangleBuilding = _goTriangleBuilding;
	}
	
	public abstract void playAnim();
    public abstract void checkNewState();
	public virtual void die() { }
    public virtual void prod() { }
}
