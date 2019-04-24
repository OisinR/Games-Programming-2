using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private enum NPCState { CHASE, PATROL };
    private NPCState state;
    private NavMeshAgent agent;
    private int m_CurrentWaypoint;
    private bool m_IsPlayerNear;
    private Animator anim;

    [SerializeField] float m_FieldOfView;
    [SerializeField] float m_ThresholdDistance;
    [SerializeField] private Transform[] m_Waypoints;
    [SerializeField] GameObject player;

    void Start()
    {

        state = NPCState.PATROL;
        agent = GetComponentInChildren<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        m_CurrentWaypoint = 0;
        
        HandleAnimation();
    }

    void Update()
    {
        CheckPlayer();
        agent.nextPosition = transform.position;

        switch (state)
        {
            case NPCState.CHASE:
                Chase();
                //Debug.Log("c");
                break;
            case NPCState.PATROL:
                Patrol();
                //Debug.Log("p");
                break;
            default:
                break;
        }

        
    }

    void CheckPlayer()
    {
        if (state == NPCState.PATROL && m_IsPlayerNear && CheckFieldOfView() && CheckOclusion())
        {
            state = NPCState.CHASE;
            HandleAnimation();
            return;
        }

        if (state == NPCState.CHASE && !CheckOclusion())
        {
            state = NPCState.PATROL;
            HandleAnimation();
        }

        if (state == NPCState.CHASE && m_IsPlayerNear && CheckFieldOfView() && CheckOclusion() && Vector3.Distance(player.transform.position, transform.position) < 3f)
        {

            Attack();
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            //state = NPCState.PATROL;
            return;
        }
    }

    void Chase()
    {
        agent.speed = 4.5f;
        agent.SetDestination(player.transform.position);
    }

    bool CheckFieldOfView()
    {
        Vector3 direction = player.transform.position - this.transform.position;
        Vector3 angle = (Quaternion.FromToRotation(transform.forward, direction)).eulerAngles;


        if (angle.y > 180.0f) angle.y = 360.0f - angle.y;
        else if (angle.y < -180.0f) angle.y = angle.y + 360.0f;


        if (angle.y < m_FieldOfView / 2)
        {
            return true;
        }

        return false;
    }

    bool CheckOclusion()
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
        //Debug.Log("Patrolling");
        agent.speed = 3.5f;
        CheckWaypointDistance();
        agent.SetDestination(m_Waypoints[m_CurrentWaypoint].position);
    }

    void Attack()
    {
        anim.SetTrigger("PlayerNear");
    }

    void CheckWaypointDistance()
    {
        if (Vector3.Distance(m_Waypoints[m_CurrentWaypoint].position, this.transform.position) < m_ThresholdDistance)
        {
            m_CurrentWaypoint = (m_CurrentWaypoint + 1) % m_Waypoints.Length;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("Player");
            m_IsPlayerNear = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            m_IsPlayerNear = false; ;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 5.0f);

        Gizmos.color = Color.red;
        Vector3 direction = player.transform.position - transform.position;
        Gizmos.DrawRay(transform.position, direction);

        Vector3 rightDirection = Quaternion.AngleAxis(m_FieldOfView / 2, Vector3.up) * transform.forward;
        Vector3 leftDirection = Quaternion.AngleAxis(-m_FieldOfView / 2, Vector3.up) * transform.forward;

        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, rightDirection * 5.0f);
        Gizmos.DrawRay(transform.position, leftDirection * 5.0f);
    }

    void HandleAnimation()
    {

        if (state == NPCState.CHASE)
        {
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }
    }
}
