using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    float horizontalMovement, verticalMovement;
    float speed = 10;
    bool jumping;
    public bool grounded;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        Vector3 movement = new Vector3(horizontalMovement, 0, verticalMovement);
        transform.Translate(movement * speed * Time.deltaTime);

        if(jumping && grounded)
        {
            rb.AddForce( new Vector3(0, 4000, 0));
        }
    }


    public void PlayerControls(float horizontal,float vertical, bool jump)
    {
        horizontalMovement = horizontal;
        verticalMovement = vertical;
        jumping = jump;
    }



}
