using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScript : MonoBehaviour
{
    public CameraLook cameraScript;
    PlayerMovement moveScript;
    Animator anim;
    Timer scoreScript;
    Options optionsScript;
    Shoot shootScript;
    public CanvasGroup fadeWin, winTextCanvas;
    public GameObject winText;
    bool dead;
    public int enemies;


    void Start()
    {
        scoreScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<Timer>();
        optionsScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<Options>();
        shootScript = GetComponent<Shoot>();
        anim = GetComponent<Animator>();
        moveScript = GetComponent<PlayerMovement>();
        fadeWin.alpha = 0;
        winTextCanvas.alpha = 0;
        winText.SetActive(false);
        AudioListener.volume = 1;
        enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    private void Update()
    {
        if(enemies <= 0)
        {
            Win();
            
        }
    }






    private void FixedUpdate()
    {
        if (dead)
        {
            fadeWin.alpha += 0.01f;
            winText.SetActive(true);
            winTextCanvas.alpha += 0.01f;
        }
    }


    private void LateUpdate()
    {
        if (dead)
        {
            Cursor.lockState = CursorLockMode.None;

            if (AudioListener.volume > 0.2f)
            {
                AudioListener.volume -= 0.01f;
            }
        }
    }

    public void Win()
    {
        dead = true;
        scoreScript.gameWon = true;
        shootScript.dead = true;
        optionsScript.dead = true;
        scoreScript.gameOver = true;
        anim.SetBool("Dead", true);
        moveScript.dead = true;
        cameraScript.paused = true;

    }

}
