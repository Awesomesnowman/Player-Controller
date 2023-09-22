using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public Vector3 finalDect;
    public bool canMove = false;
    // Start is called before the first frame update
    void Start()
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

    void Update()
    {
        if (gameObject.GetComponent<Plane>().canMove == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, gameObject.GetComponent<Plane>().finalDect, 2f * Time.deltaTime);
            if (Vector3.Distance(transform.position, finalDect) < 0.5f)
                canMove = false;
        }
    }
}