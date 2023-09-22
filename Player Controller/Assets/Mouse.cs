using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public Vector3 finalDect;
    GameObject plane;
    // Start is called before the first frame update
    void Start()
    {
        finalDect = new Vector3(0,0,0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        plane = collision.gameObject;
    }
    void Update()
    {
        finalDect = plane.GetComponent<Plane>().finalDect;
        Debug.Log(finalDect);
        transform.position = Vector3.MoveTowards(transform.position, finalDect, 2f * Time.deltaTime);
    }
}