using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    public AudioClip death;
    AudioSource speaker;
    public CameraLook cameraScript;
    PlayerMovement moveScript;
    Animator anim;
    Timer scoreScript;
    Options optionsScript;
    Shoot shootScript;
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
        fade.alpha = 0;
        deathTextCanvas.alpha = 0;
        deathText.SetActive(false);
        AudioListener.volume = 1;
    }


    private void FixedUpdate()
    {
        if(dead)
        {
            fade.alpha += 0.01f;
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
