using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector2 Forward;
    Rigidbody myRig;
    private float speed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        myRig = GetComponent<Rigidbody>();
        if (myRig == null)
            throw new System.Exception("Player controller needs rigidbody");

        move();
    }

    void move()
    {
        Forward.x = speed;
    }

    void OnCollisionEnter(Collision other)
    {
        myRig.useGravity = false;
        if (other.gameObject.tag == "ground")
        {

        }
        else
        {
            speed = speed * -1;
            //Forward.x = speed;
        }
    }

    void OnCollisionExit(Collision other)
    {
        Debug.Log("Exit");
        if(other.gameObject.tag == "ground")
        {
            speed = speed * -1;
            //Forward.x = speed;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //myRig.angularVelocity = new Vector3(Forward.x, 0, 0);
        myRig.velocity = myRig.transform.forward * speed;
    }
}
