using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector3 lastDirection;
    public Rigidbody myRig;
    public float speed = .5f;
    public float jumpSpeed = 8.0f;
    // Start is called before the first frame update
    void Start()
    {
        myRig = GetComponent<Rigidbody>();
        if (myRig == null)
            throw new System.Exception("Player controller needs rigidbody");
    }
    public void onMove(InputAction.CallbackContext ev)
    {
        if (ev.performed)
        {
            lastDirection = ev.ReadValue<Vector2>();
        }
        if (ev.canceled)
        {
            lastDirection = Vector2.zero;
        }
    }
    public void onJump(InputAction.CallbackContext ev)
    {
        if (ev.started)
        {
            myRig.velocity += new Vector3(0, jumpSpeed, 0);
        }
        if (ev.canceled)
        {
            myRig.velocity -= new Vector3(0, jumpSpeed, 0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        myRig.angularVelocity = new Vector3(lastDirection.x, 0, 0);
        myRig.velocity += transform.forward * speed * lastDirection.x;
    }
}