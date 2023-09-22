using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Vector2 Forward;
    Rigidbody myRig;
    private float speed = 0.75f;

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
        if (other.gameObject.tag == "ground")
        {
            speed = speed * -1;
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().platform = transform.forward * speed;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().platform = new Vector3(0, 0, 0);
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
