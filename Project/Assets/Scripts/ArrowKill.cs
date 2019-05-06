using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKill : MonoBehaviour
{
    public bool canKill;
   
	void Awake()
    {
        canKill = true; 
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 10)                                    //If it hits an enemy, try to kill them
        {
            if(canKill)
            {
                try
                {
                    collision.gameObject.GetComponent<Death>().Die();
                }
                catch(System.Exception e)
                {
                    Debug.Log(e, this);
                }
            }
        }
        if(collision.gameObject.layer == 9)                                     //if the arrow hits the environment it cant kill anymore, preventing monsters dying by walking on it
        {
            canKill = false;
        }
    }



}
