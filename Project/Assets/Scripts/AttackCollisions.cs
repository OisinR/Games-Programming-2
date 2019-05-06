using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollisions : MonoBehaviour
{

    public bool triggerEnabled;                                             //accessed from enem attack script



    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.layer == 11)
        {
            if (triggerEnabled)                                             //if hit the player and can kill, try to kill               
            {
                try
                {
                    other.gameObject.GetComponent<PlayerDeath>().Die();
                }
                catch
                {

                }
            }
        }
    }



}
