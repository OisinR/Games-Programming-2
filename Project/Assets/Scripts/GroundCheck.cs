using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    bool groundUnderneath;
    PlayerMovement playerMovementScript;

    private void Start()
    {
        playerMovementScript = GetComponentInParent<PlayerMovement>();
    }

    void Update()
    {
        playerMovementScript.grounded = groundUnderneath;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == 9)
        {
            groundUnderneath = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == 9)
        {
            groundUnderneath = false;
        }
    }

}
