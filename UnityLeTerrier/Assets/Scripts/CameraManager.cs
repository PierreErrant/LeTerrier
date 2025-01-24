using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime;

    private float distanceToPlayer;
    private Vector2 mouseInput;

    [SerializeField] private MouseSensitivity mouseSensitivity;
    [SerializeField] private CameraAngle cameraAngle;
    
    private CameraRotation cameraRotation;

    private float mouseWheel =0.0f ;
    private float cameraDistance;
    [SerializeField] private CameraZoom cameraZoom;


    private void Awake()
    {
        distanceToPlayer = Vector3.Distance(transform.position, target.position);
        cameraDistance = Vector3.Distance(transform.position, target.position);
    }
    public void Look(InputAction.CallbackContext context) 
    {
        mouseInput = context.ReadValue<Vector2>();
    }
   
    public void Zoom(InputAction.CallbackContext context)
    {
        mouseWheel = context.ReadValue<float>();
    }
    private void Update()
    {
        cameraRotation.yaw += mouseInput.x * mouseSensitivity.horizontal * BoolToInt(mouseSensitivity.horizontalInverted) * Time.deltaTime;
        cameraRotation.pitch += mouseInput.y * mouseSensitivity.vertical * BoolToInt(mouseSensitivity.verticalInverted) * Time.deltaTime;
        cameraRotation.pitch = Mathf.Clamp(cameraRotation.pitch, cameraAngle.min, cameraAngle.max);
        cameraRotation.pitch = Mathf.Clamp(cameraRotation.pitch, cameraAngle.min, cameraAngle.max);
        ApplyZoom();
    }

    private void LateUpdate()
    {
        transform.eulerAngles = new Vector3(cameraRotation.pitch, cameraRotation.yaw, 0.0f);
        transform.position = target.position - transform.forward *  cameraDistance;
    }
    private static int BoolToInt(bool b) => b ? 1 : -1;
    
    private void ApplyZoom()
    {
        cameraDistance += mouseWheel * 0.5f;
        cameraDistance = Mathf.Clamp(cameraDistance, cameraZoom.min, cameraZoom.max) ;
        UnityEngine.Debug.Log(distanceToPlayer);
    }

}

[Serializable]

public struct MouseSensitivity
{
    public float horizontal;
    public float vertical;
    public bool verticalInverted;
    public bool horizontalInverted;
}

public struct CameraRotation
{
    public float pitch;
    public float yaw;
}

[Serializable]

public struct CameraAngle
{
    public float min;
    public float max;
}

[Serializable]

public struct CameraZoom
{
    public float min;
    public float max;
}