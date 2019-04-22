using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerMovement playerMovementScript;
    CameraLook cameraScript;
    Vector2 rotation = Vector2.zero;
    float horizontal, vertical;
    public bool jump;
    public float sensitivity;


    void Start()
    {
        playerMovementScript = GetComponent<PlayerMovement>();
        cameraScript = GetComponentInChildren<CameraLook>();
    }




	void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        jump = Input.GetButtonDown("Jump");
        playerMovementScript.PlayerControls(horizontal,vertical, jump);

        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        cameraScript.Look(rotation);

    }



}
