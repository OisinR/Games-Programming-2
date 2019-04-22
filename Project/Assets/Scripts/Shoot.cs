using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    float ammo = 1;
    public float speed;
    public GameObject crossArrow;
    public GameObject fireArrow;


	void Start()
    {
    }

    public void Fire(bool shoot)
    {
        if (shoot && ammo >= 1)
        {
            crossArrow.SetActive(false);
            GameObject shot = Instantiate(fireArrow, crossArrow.transform.position, crossArrow.transform.rotation);
            shot.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
            shot.GetComponent<Rigidbody>().AddForce(transform.up * 50);
        }

    }

}
