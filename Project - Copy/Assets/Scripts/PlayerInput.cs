using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerMovement playerMovementScript;
    CameraLook cameraScript;
    Shoot shootScript;

    Vector2 rotation = Vector2.zero;
    float horizontal, vertical;
    public bool jump;
    public float sensitivity;
    bool shoot;

    void Start()
    {
        playerMovementScript = GetComponent<PlayerMovement>();
        cameraScript = GetComponentInChildren<CameraLook>();
        shootScript = GetComponent<Shoot>();
    }




    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        jump = Input.GetButtonDown("Jump");
        playerMovementScript.PlayerControls(horizontal, vertical, jump);

        shoot = Input.GetButtonDown("Fire1");
        shootScript.Fire(shoot);
    }

    private void LateUpdate()
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        cameraScript.Look(rotation);
    }



}
