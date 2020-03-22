using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float rotateSensHoriz;
    [SerializeField] protected float rotateSensVert;
    [SerializeField] protected float maxVertAngle = 45.0f;
    
    private Rigidbody _rigidbody;
    private Transform _cameraTransform;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _cameraTransform = GetComponentInChildren<Camera>().GetComponent<Transform>();
    }
    
    void Update()
    {
        _rigidbody.velocity = GetMovementVector();
        transform.localEulerAngles = GetRotationY();
        _cameraTransform.localEulerAngles = GetRotationX();
    }

    private Vector3 GetRotationX()
    {
        var cameraRotation = _cameraTransform.localEulerAngles;
        var rotation = cameraRotation;

        rotation.x -= Input.GetAxis("Mouse Y"); // vertical
        rotation.x = Mathf.Lerp(cameraRotation.x, rotation.x, Time.deltaTime * rotateSensVert);
        rotation.x = rotation.x > 180 ? rotation.x - 360 : rotation.x;
        rotation.x = Mathf.Clamp(rotation.x, -maxVertAngle, maxVertAngle);
        return rotation;
    }

    private Vector3 GetRotationY()
    {
        var transformRotation = transform.localEulerAngles;
        var rotation = transformRotation;
        
        rotation.y += Input.GetAxis("Mouse X"); // horizontal
        rotation.y = Mathf.Lerp(transformRotation.y, rotation.y, Time.deltaTime * rotateSensHoriz);
        return rotation;
    }

    private Vector3 GetMovementVector()
    {
        var cachedTransform = transform;
        var moveForward = cachedTransform.forward;
        var moveSide = cachedTransform.right;
        
        moveForward *= Time.deltaTime * moveSpeed * Input.GetAxis("Vertical");
        moveSide *= Time.deltaTime * moveSpeed * Input.GetAxis("Horizontal");
        return moveForward + moveSide;
    }
}
