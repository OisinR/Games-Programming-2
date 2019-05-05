using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Collider col;
    bool triggerEnabled = false;
    public AttackCollisions colScript;
    public AudioSource speaker;
    public AudioClip swipe;

    public void CanKill()
    {
        col.enabled = true;
        colScript.triggerEnabled = true;
        speaker.volume = PlayerPrefs.GetFloat("MonsterVolume");
        speaker.PlayOneShot(swipe);
    }




	public void CantKill()
    {
        col.enabled = false;
        colScript.triggerEnabled = false;
    }



}
