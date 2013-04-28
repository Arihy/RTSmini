using UnityEngine;
using System.Collections;

public class DragDrop : MonoBehaviour {

    private Ray ray;
    private RaycastHit hit;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y, transform.position.z);
            }

        }
	
	}
}
