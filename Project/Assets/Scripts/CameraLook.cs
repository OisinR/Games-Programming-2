﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    PlayerInput playerInput;
    public float sensitivity;
    private Vector2 rotation = Vector2.zero;
    public GameObject Character;
    public bool paused;

    private void Start()
    {
        playerInput = GetComponentInParent<PlayerInput>();
        sensitivity = playerInput.sensitivity;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Look(Vector2 rotation)
    {
        if(paused)
        {
            return;                 //dont allow movement if paused
        }
        rotation.x = Mathf.Clamp(rotation.x, -15f, 15f);
        Character.transform.localRotation = Quaternion.Euler(0, rotation.y * sensitivity, 0);           //look up and down
        Camera.main.transform.parent.localRotation = Quaternion.Euler(rotation.x * sensitivity, 0, 0);  //rotate body, not just head

    }
}