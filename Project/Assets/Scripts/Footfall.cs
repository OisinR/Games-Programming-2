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

        if (scale > 0) // left foot
        {
            footDirection = Direction.left;
        }
        else // right foot
        {
            footDirection = Direction.right;
        }

        PlaySound(footDirection);
    }

    private void PlaySound(Direction footDirection)
    {
        speaker.volume = PlayerPrefs.GetFloat("EffectsVolume");
        if (speaker != null)
        {
            if (footDirection == Direction.left)
            {
                speaker.panStereo = -0.5f;
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