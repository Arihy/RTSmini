using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoxSelection : MonoBehaviour {

    public Texture2D selectionHighlight;
    public static Rect selection = new Rect(0, 0, 0, 0);
    private Vector3 startClick = -Vector3.one;



    //Coordonnée de la destination (quand on a clické sur le bouton droit)
    private static Vector3 moveTo = Vector3.one;

    //liste des zones sur lesquels on peut marcher
    private static List<string> walkables = new List<string>() { "Floor" };



	// Use this for initialization
	void Start () {
        Debug.Log("BoxSelection");
	}
	
	// Update is called once per frame
	void Update()
    {
        CheckCamera();
        clear();
    }


    private void CheckCamera()
    {
        if(Input.GetMouseButtonDown(0))
        {
            startClick = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            startClick = -Vector3.one;
        }

        if (Input.GetMouseButton(0))
        {
            selection = new Rect(startClick.x, InvertMouseY(startClick.y), Input.mousePosition.x - startClick.x, InvertMouseY(Input.mousePosition.y) - InvertMouseY(startClick.y));
            if (selection.width < 0)
            {
                selection.x += selection.width;
                selection.width = -selection.width;
            }
            if (selection.height < 0)
            {
                selection.y += selection.height;
                selection.height = -selection.height;
            }
        }

        if (Input.GetMouseButton(1))
        {
            moveTo = Input.mousePosition;
            Debug.Log("MoveTo : " + moveTo);
        }
    }

    private void clear()
    {
        if (!Input.GetMouseButtonUp(1))
            moveTo = Vector3.zero;
    }

    private void OnGUI()
    {
        if (startClick != -Vector3.one)
        {
            GUI.color = new Color(1, 1, 1, 0.5f);
            GUI.DrawTexture(selection, selectionHighlight);
        }
    }

    public static float InvertMouseY(float y)
    {
        return Screen.height - y;

    }

    public static Vector3 getDestination()
    {
        if (moveTo == Vector3.zero)
        {
            RaycastHit hit;
            Ray r = Camera.mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(r, out hit))
            {
                while (!walkables.Contains(hit.transform.gameObject.name))
                {
                    if (!Physics.Raycast(hit.point, r.direction, out hit))
                    {
                        break;
                    }
                }
            }

            if(hit.transform != null)
                moveTo = hit.point;
        }
        return moveTo;
    }

	
}


