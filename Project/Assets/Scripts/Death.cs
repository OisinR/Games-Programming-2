using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Death : MonoBehaviour
{
    //Enemy Death
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
        GameObject.FindGameObjectWithTag("Player").GetComponent<WinScript>().enemies--;         //tell the WinScript that theres one less enemy in the scene
        speaker.volume = PlayerPrefs.GetFloat("MonsterVolume");     
        speaker.PlayOneShot(deathSound);                                                        //Play death sound
        anim.SetBool("Death",true);                                                             //Play death animation
        hitCol.enabled = false;                                                                 //disbale collider
        Destroy(agent);                                                                         //get rid of the navmesh agent, rigidbody and the enemy script
        Destroy(enemyScript);
        Destroy(rb);
        col.enabled = false;
        Instantiate(particles, transform.position, Quaternion.identity);                        //Instantiate in some blood

    }

}
