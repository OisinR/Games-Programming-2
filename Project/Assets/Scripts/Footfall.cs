using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footfall : MonoBehaviour
{
    public AudioClip footstep;
    private enum Direction { right, left };
    private Animator anim;
    public AudioSource speaker;




    public void MakeFootprint(int scale)
    { 

        Direction footDirection;

        if (scale > 0) 
        {
            footDirection = Direction.left;
        }
        else 
        {
            footDirection = Direction.right;
        }

        PlaySound(footDirection);
    }

    private void PlaySound(Direction footDirection)
    {
        if (gameObject.layer == 11)
        {
            speaker.volume = PlayerPrefs.GetFloat("EffectsVolume");
        }
        else
        {
            speaker.volume = PlayerPrefs.GetFloat("MonsterVolume");
        }
        if (speaker != null)
        {
            if (footDirection == Direction.left)
            {
                speaker.panStereo = -0.5f;                                          //sets footprint sounds to sound a little different on each step
                speaker.pitch = Random.Range(1.0f, 1.5f);
            }

            if (footDirection == Direction.right)
            {
                speaker.panStereo = +0.5f;
                speaker.pitch = Random.Range(1.5f, 2.0f);
            }

            speaker.PlayOneShot(footstep);
        }
    }
}