using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayStil : MonoBehaviour
{

    //makes sure it doesnt wander off during animations
	void Update()
    {
        transform.position = gameObject.transform.parent.position;
    }



}
