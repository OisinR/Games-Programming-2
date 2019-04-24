using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayStil : MonoBehaviour
{

   
	void Start()
    {
        
    }




	void Update()
    {
        transform.position = gameObject.transform.parent.position;
    }



}
