using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    //set up variables

        //for death sound
    public AudioClip death;
    AudioSource speaker;

        //references to other scripts
    public CameraLook cameraScript;
    PlayerMovement moveScript;
    Animator anim;
    Timer scoreScript;
    Options optionsScript;
    Shoot shootScript;

        //Canvas groups to allow the end screens to fade in via alpha channel
    public CanvasGroup fade, deathTextCanvas;
    public GameObject deathText;
    bool dead;

	void Start()
    {
        scoreScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<Timer>();
        optionsScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<Options>();
        shootScript = GetComponent<Shoot>();
        anim = GetComponent<Animator>();
        moveScript = GetComponent<PlayerMovement>();
        speaker = GetComponent<AudioSource>();
        fade.alpha = 0;                                                                     //set everything to off/transparent at the start
        deathTextCanvas.alpha = 0;
        deathText.SetActive(false);
        AudioListener.volume = 1;
    }


    private void FixedUpdate()
    {
        if(dead)
        {
            fade.alpha += 0.01f;                                                                //if dead, fade in the game over screen
            deathText.SetActive(true);
            deathTextCanvas.alpha += 0.01f;
        }
    }


    private void LateUpdate()
    {
        if(dead)
        {
            Cursor.lockState = CursorLockMode.None;

            if(AudioListener.volume > 0.2f)
            {
                AudioListener.volume -= 0.01f;
            }
        }
    }

    public void Die()
    {
        if (dead) { return; }
        dead = true;
        shootScript.dead = true;
        optionsScript.dead = true;
        Debug.Log("Hit");
        scoreScript.gameOver = true;
        speaker.PlayOneShot(death);
        anim.SetBool("Dead", true);
        moveScript.dead = true;
        cameraScript.paused = true;

    }

}
