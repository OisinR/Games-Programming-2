using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    bool groundUnderneath;
    PlayerMovement playerMovementScript;
    Animator anim;

    private void Start()
    {
        playerMovementScript = GetComponentInParent<PlayerMovement>();
        anim = GetComponentInParent<Animator>();
    }

    void Update()
    {
        playerMovementScript.grounded = groundUnderneath;           //if next to the ground, tell the Movement script it can jump
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == 9)
        {
            anim.SetBool("Grounded", true);
            groundUnderneath = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == 9)
        {
            anim.SetBool("Grounded", false);
            groundUnderneath = false;
        }
    }

}
