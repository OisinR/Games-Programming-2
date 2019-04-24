using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Collider col;
    bool triggerEnabled = false;
    public AttackCollisions colScript;

	public void CanKill()
    {
        col.enabled = true;
        colScript.triggerEnabled = true;
    }




	public void CantKill()
    {
        col.enabled = false;
        colScript.triggerEnabled = false;
    }



}
