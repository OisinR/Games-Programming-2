using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text timerText;
    public bool gameOver;
    public bool gameWon;
    float timer;


	void Start()
    {
        timer = 0;
    }




	void Update()
    {
        if (!gameOver && !gameWon)                                      //if the game isnt over, keep adding to the time
        {
            timer += Time.deltaTime;
            timerText.text = "Time: " + timer.ToString("0.00");
        }

        if(gameWon)
        {
            float score = PlayerPrefs.GetFloat("Score");
            if (timer < score)                                          //if the game is won and new time is better than old time, replace old time
            {
                PlayerPrefs.SetFloat("Score", timer);
            }
        }

    }



}
