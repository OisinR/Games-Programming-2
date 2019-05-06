using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private enum EnemyState { CHASE, PATROL };
    private EnemyState state;
    private NavMeshAgent agent;
    private int currentWaypoint;
    private bool playerNearMe;
    private Animator anim;
    bool played;
    float fieldOfView = 240;
    float threshold = 4;
    public Transform[] waypoints;
    GameObject player;
    AudioSource speaker;
    public AudioClip getAttention;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        state = EnemyState.PATROL;
        agent = GetComponentInChildren<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        currentWaypoint = 0;
        speaker = GetComponent<AudioSource>();
        HandleAnimation();
    }

    void Update()
    {
        CheckPlayer();
        agent.nextPosition = transform.position;

        switch (state)
        {
            case EnemyState.CHASE:
                Chase();
                break;
            case EnemyState.PATROL:
                Patrol();
                break;
            default:
                break;
        }

        
    }

    void CheckPlayer()
    {
        if (state == EnemyState.PATROL && playerNearMe && CheckFieldOfView() && CheckOclusion())            //if can see player and they're close then chase them
        {
            state = EnemyState.CHASE;
            HandleAnimation();
            return;
        }

        if (state == EnemyState.CHASE && !CheckOclusion())                                                  
        {
            state = EnemyState.PATROL;
            HandleAnimation();
        }

        if (state == EnemyState.CHASE && playerNearMe && CheckFieldOfView() && CheckOclusion() && Vector3.Distance(player.transform.position, transform.position) < 2f) //if close and chasing, attack the player
        {

            Attack();
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            return;
        }
    }

    void Chase()
    {
        agent.speed = 4.5f;
        if (!played)
        {
            speaker.volume = PlayerPrefs.GetFloat("MonsterVolume");
            speaker.PlayOneShot(getAttention);
            played = true;
        }
        agent.SetDestination(player.transform.position);

        if(Vector3.Distance(player.transform.position, transform.position) < 2f)
        {
            agent.updateRotation = false;
            transform.LookAt(player.transform);
        }
        else
        {
            agent.updateRotation = true;
        }
    }

    bool CheckFieldOfView()                                                                                     //is the player in the feild of view 
    {
        Vector3 direction = player.transform.position - this.transform.position;
        Vector3 angle = (Quaternion.FromToRotation(transform.forward, direction)).eulerAngles;


        if (angle.y > 180.0f) angle.y = 360.0f - angle.y;
        else if (angle.y < -180.0f) angle.y = angle.y + 360.0f;


        if (angle.y < fieldOfView / 2)
        {
            return true;
        }

        return false;
    }

    bool CheckOclusion()                                                                                //is the player hidden
    {
        RaycastHit hit;
        Vector3 direction = player.transform.position - transform.position;

        int layerMask = 1 << 10;
        if (Physics.Raycast(this.transform.position, direction, out hit, layerMask))
        {

                return true;
        }
        return false;
    }

    void Patrol()
    {
        agent.speed = 3.5f;
        CheckWaypointDistance();
        agent.SetDestination(waypoints[currentWaypoint].position);
    }

    void Attack()
    {
        anim.SetTrigger("PlayerNear");
    }

    void CheckWaypointDistance()
    {
        if (Vector3.Distance(waypoints[currentWaypoint].position, this.transform.position) < threshold)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerNearMe = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerNearMe = false; ;
        }
    }

    void HandleAnimation()
    {

        if (state == EnemyState.CHASE)
        {
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }
    }
}
