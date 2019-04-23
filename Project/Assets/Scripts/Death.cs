using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{

    Rigidbody rb;
    Collider col;
    MeshRenderer rend;
    public GameObject particles;

	void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        rend = GetComponent<MeshRenderer>();
    }

    public void Die()
    {
        Destroy(rend);
        Destroy(rb);
        col.enabled = false;
        Instantiate(particles, transform.position, Quaternion.identity);
    }

}
