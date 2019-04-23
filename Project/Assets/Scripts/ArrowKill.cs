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




	void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 10)
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
        if(collision.gameObject.layer == 9)
        {
            canKill = false;
        }
    }



}
