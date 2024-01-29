using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    public Vector3 playerVelocity;
    public float speed = 5f;
    public float gravity = -9.8f;

    public Boolean isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerVelocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }
        public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = new(input.x, 0, input.y);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        controller.Move(moveDirection * Time.deltaTime);
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
