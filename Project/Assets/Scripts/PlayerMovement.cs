using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator anim;
    float horizontalMovement, verticalMovement;
    float speed = 5;
    bool jumping;
    public bool grounded;
    Rigidbody rb;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        transform.position += transform.forward * verticalMovement * speed * Time.deltaTime;
        transform.position += transform.right * horizontalMovement * speed * Time.deltaTime;
        if(verticalMovement + horizontalMovement < -0.1f || verticalMovement + horizontalMovement > 0.1f)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }
        
        if (jumping && grounded)
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
