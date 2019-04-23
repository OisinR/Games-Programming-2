using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Death : MonoBehaviour
{

    Rigidbody rb;
    Collider col;
    MeshRenderer[] rend;
    Enemy enemyScript;
    NavMeshAgent agent;
    public GameObject particles;
    Animator anim;
	void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        enemyScript = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        rend = GetComponentsInChildren<MeshRenderer>();
    }

    public void Die()
    {
        anim.SetTrigger("Death");
        Destroy(agent);
        Destroy(enemyScript);
        Destroy(rb);
        col.enabled = false;
        Instantiate(particles, transform.position, Quaternion.identity);

    }

}
