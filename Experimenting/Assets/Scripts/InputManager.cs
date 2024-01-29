using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnDrivingActions onDriving;
    private PlayerMotor motor;
    private float k = 1f;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        onDriving = playerInput.onDriving;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        motor.ProcessMove(onDriving.Movement.ReadValue<Vector2>()*k);
    }
    private void OnEnable()
    {
        onDriving.Enable();
    }
    private void OnDisable()
    {
        onDriving.Disable();
    }
}
