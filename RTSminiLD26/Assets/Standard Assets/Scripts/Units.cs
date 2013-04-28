using UnityEngine;
using System.Collections;

public class Units : MonoBehaviour {

    public bool selected = false;

    public virtual void Start()
    {
        Debug.Log("start Units");
    }
	
	// Update is called once per frame
	public virtual void Update () {

        if (renderer.isVisible && Input.GetMouseButton(0))
        {
            Vector3 camPos = Camera.mainCamera.WorldToScreenPoint(transform.position);
            camPos.y = BoxSelection.InvertMouseY(camPos.y);
            selected = BoxSelection.selection.Contains(camPos);
        }

        if (selected)
        {
            renderer.material.color = Color.red;

        }
        else
            renderer.material.color = Color.white;
	
	}
}
