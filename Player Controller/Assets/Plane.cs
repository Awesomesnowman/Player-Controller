using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public Vector3 finalDect;
    public bool canMove = false;
    private void Start()
    {
        finalDect = new Vector3(0, 0, 0);
    }

    private void Update()
    {
     
    }

    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit myCheck;

        if (Physics.Raycast(ray, out myCheck))
        {
            Debug.Log("We hit" + myCheck.point.x + "," + myCheck.point.y + "," + myCheck.point.z);
            finalDect = new Vector3(myCheck.point.x, transform.position.y, myCheck.point.z);
            canMove = true;
        }
    }
}
