using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    PlayerInput playerInput;
    public float sensitivity;
    private Vector2 rotation = Vector2.zero;


    private void Start()
    {
        playerInput = GetComponentInParent<PlayerInput>();
        sensitivity = playerInput.sensitivity;
    }

    public void Look(Vector2 rotation)
    {
        rotation.x = Mathf.Clamp(rotation.x, -15f, 15f);
        Camera.main.transform.parent.localRotation = Quaternion.Euler(rotation.x * sensitivity, rotation.y * sensitivity, 0);
    }

}