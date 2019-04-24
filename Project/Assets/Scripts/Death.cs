using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Death : MonoBehaviour
{
    public AudioClip deathSound;
    AudioSource speaker;
    Rigidbody rb;
    Collider col;
    MeshRenderer[] rend;
    Enemy enemyScript;
    NavMeshAgent agent;
    public GameObject particles;
    Animator anim;
    public Collider hitCol;
	void Awake()
    {
        speaker = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        enemyScript = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        rend = GetComponentsInChildren<MeshRenderer>();
    }

    public void Die()
    {
        speaker.volume = PlayerPrefs.GetFloat("MonsterVolume");
        speaker.PlayOneShot(deathSound);
        anim.SetTrigger("Death");
        hitCol.enabled = false;
        Destroy(agent);
        Destroy(enemyScript);
        Destroy(rb);
        col.enabled = false;
        Instantiate(particles, transform.position, Quaternion.identity);

    }

}
