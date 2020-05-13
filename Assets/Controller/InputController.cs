using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour, IMoveInput, IRotationInput, IZoomInput, IMouseInput
{

    //central PlayerInputActions
    public PlayerInputActions _inputActions;

    //CameraControls
    public Vector2 MoveDirection { get; private set; }

    public float RotationDirection { get; private set; }

    public float ZoomDirection { get; private set; }

    //HexGrid Controls
    public bool MouseClickLeft { get; private set; }
    public Vector2 MousePosition {get; private set; }

    private void Awake()
    {
        _inputActions = new PlayerInputActions();
        _inputActions.Enable();
    }

    private void OnEnable()
    {
        //Camera
        _inputActions.Camera.MoveCamera.performed += OnMoveCameraInput;
        _inputActions.Camera.RotateCamera.performed += OnRotateCameraInput;
        _inputActions.Camera.Zoom.performed += OnZoomCameraInput;

        //HexGrid
        _inputActions.UI.MouseClick.performed += OnMouseClickLeft;
        _inputActions.UI.MousePosition.performed += OnMousePosition;
    }

    private void OnDisable()
    {
        _inputActions.Camera.MoveCamera.performed -= OnMoveCameraInput;
        _inputActions.Camera.RotateCamera.performed -= OnRotateCameraInput;
        _inputActions.Camera.Zoom.performed -= OnZoomCameraInput;

        //HexGrid
        _inputActions.UI.MouseClick.performed -= OnMouseClickLeft;
    }



    //Camera Controls
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


    // HexGrid Controls
    private void OnMouseClickLeft(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        //Debug.Log("Mouse Left Click Value: " + value);
        if (value > 0.5f)
        {
            MouseClickLeft = true;
            //Debug.Log("Click");
        }
        else
        {
            MouseClickLeft = false;
        }
        
    }

    private void OnMousePosition(InputAction.CallbackContext context) 
    {
        var value = context.ReadValue<Vector2>();
        //Debug.Log(value);
        MousePosition = value;
    }

    public PlayerInputActions getInputActions()
    {
        return this._inputActions;
    }
}
