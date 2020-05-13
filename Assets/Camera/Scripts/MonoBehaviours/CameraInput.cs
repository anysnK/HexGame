/* using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Camera.Scripts.MonoBehaviours
{
    public class CameraInput : MonoBehaviour, IMoveInput, IRotationInput, IZoomInput
    {
        private PlayerInputActions _inputActions;

        public Vector2 MoveDirection { get; private set; }

        public float RotationDirection { get; private set; }

        public float ZoomDirection { get; private set; }

        private void Awake() 
        {
            _inputActions = new PlayerInputActions();
            _inputActions.Enable();
        }

        private void OnEnable() 
        {
            _inputActions.Camera.MoveCamera.performed += OnMoveCameraInput;
            _inputActions.Camera.RotateCamera.performed += OnRotateCameraInput;
            _inputActions.Camera.Zoom.performed += OnZoomCameraInput;
        }

        private void OnDisable() 
        {
            _inputActions.Camera.MoveCamera.performed -= OnMoveCameraInput;
            _inputActions.Camera.RotateCamera.performed -= OnRotateCameraInput;
            _inputActions.Camera.Zoom.performed -= OnZoomCameraInput;
        }

        private void OnMoveCameraInput(InputAction.CallbackContext context) 
        {
            var value = context.ReadValue<Vector2>();
            MoveDirection = value;
        }

        private void OnRotateCameraInput(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<float>();
            RotationDirection = value;
        }

        private void OnZoomCameraInput(InputAction.CallbackContext context)
        {
            var value = Mathf.Clamp(context.ReadValue<float>(), -1f, 1f);
            //Debug.Log(value);
            ZoomDirection = value;
        }

        

        
    }

    
} */