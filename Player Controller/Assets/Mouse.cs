using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    private Vector3 finalDect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (gameObject.GetComponent<Plane>().canMove == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, gameObject.GetComponent<Plane>().finalDect, 2f * Time.deltaTime);
        }
    }
}
