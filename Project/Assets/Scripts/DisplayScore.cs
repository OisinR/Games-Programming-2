﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{

    public Text scoreText;
	void Start()
    {
        scoreText.text = "Best Time: " + PlayerPrefs.GetFloat("Score").ToString("0.00") + " seconds";
    }






}
