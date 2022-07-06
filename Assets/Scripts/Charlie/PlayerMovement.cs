using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// Charlie
    /// </summary>
    private float gravity = 9.71f;
    private CharacterController _characterController;
    private Vector3 _charVelocity;
    private Vector3 _charMove;
    private float _cameraVerticalAngle;
    private PickUp _pickUp;
   

    [Header("Character Settings",order = 1)]
    [Range(0,10)]public float _CharSpeed = 10f;
    [Range(0, 5)] public float Gravity_Multiplier;
    [Range(0, 5)] public float JumpForce = 10f;

    [Header("Camera Settings",order = 2)]
    [SerializeField]private Camera _camera;
    public Vector2 _cameraSpeedMuliplier = new Vector2(0, 0);
    [Range(0,90)]public float _CamMaxY = 70f;
    [Range(0,-90)]public float _CamMinY = -70f;
    
    

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _pickUp = gameObject.GetComponentInChildren<PickUp>();
    }

    
    
    private void Update()
    {
        if (_pickUp.keypad == false)
        {
            HandleCameraMovement();
            if (_characterController.isGrounded)
            { 
                HandleGroundMovement();
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _charVelocity += Vector3.up * JumpForce;
                }
            }
            else
            {
                //TODO: Air Movement
            }
        
            _charVelocity += Vector3.down * (gravity * Time.deltaTime * Gravity_Multiplier );
        
            _characterController.Move(_charVelocity * Time.deltaTime);

        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
       
    }
    
    
    void HandleCameraMovement()
    {
        //input from axes
        Vector2 inputAxes = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        
        //multiplies the input speed
        inputAxes.Scale(_cameraSpeedMuliplier);
        
        transform.Rotate(Vector3.up, inputAxes.x, Space.Self);

        _cameraVerticalAngle -= inputAxes.y;
        
        _cameraVerticalAngle = Mathf.Clamp(_cameraVerticalAngle, _CamMinY, _CamMaxY);

        _camera.transform.localEulerAngles = new Vector3(_cameraVerticalAngle, 0f, 0f);

    }
    private void HandleGroundMovement()
    {
        //input from movement axes
        Vector2 inputAxes = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        //converts Vector2 Co-ords to Vector3 Co-ords
        Vector3 inputSpaceMovement = new Vector3(inputAxes.x, 0f, inputAxes.y) * _CharSpeed;

        //uses inputSpaceMovement to transform the player
        Vector3 worldSpaceMovement = transform.TransformVector(inputSpaceMovement);

        _charVelocity = worldSpaceMovement;

    }
}
