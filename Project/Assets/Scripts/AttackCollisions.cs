using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollisions : MonoBehaviour
{

    public bool triggerEnabled;




    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.layer == 11)
        {
            if (triggerEnabled)
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
