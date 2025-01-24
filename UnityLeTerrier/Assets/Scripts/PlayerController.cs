using System;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    private Vector2 input;
    private CharacterController characterController;
    private Vector3 direction;

    [SerializeField] private float rotationSpeed = 500f;

    [SerializeField] private float speed;

    private float gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 1.0f;
    private float velocity;

    [SerializeField] private float jumpPower = 4.0f;

    private Camera mainCamera;

    private void Awake()
    {
       characterController = GetComponent<CharacterController>();
       mainCamera = Camera.main;
    }

    private void Update()
    {
        ApplyRotation();
        ApplyGravity();
        ApplyMouvement();
        UnityEngine.Debug.Log(transform.rotation);
    }
   
    private void ApplyRotation()
    {
        if (input.sqrMagnitude == 0) return;
        direction = Quaternion.Euler(0.0f, mainCamera.transform.eulerAngles.y, 0.0f) * new Vector3(input.x, 0.0f, input.y);
        var targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
       // UnityEngine.Debug.Log(direction);
    }
    
    private void ApplyMouvement()
    {
        characterController.Move(direction* speed * Time.deltaTime);
    }
    
    private void ApplyGravity()
    {
        if (IsGrounded() && velocity < 0.0f)
        {
            velocity = -1.0f;
        }
        else
        {
            velocity += gravity * gravityMultiplier * Time.deltaTime;

        }
        direction.y = velocity;
    }
    
    public void Move(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
        direction = new Vector3(input.x, 0.0f, input.y);
    }
    
    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (!IsGrounded()) return;
        velocity += jumpPower;
    }

    private bool IsGrounded() => characterController.isGrounded;
}
