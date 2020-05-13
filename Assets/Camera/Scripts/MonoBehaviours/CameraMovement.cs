using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour
{
    //References
    private Camera mainCam;
    

    //Tweaks
    [SerializeField]private float movementTime;
    [SerializeField]private float movementSpeed;
    [SerializeField]private float rotationSpeed;
    [SerializeField]private float rotationTime;
    [SerializeField]private Vector3 zoomSpeed;
    [SerializeField]private float zoomTime;
    [SerializeField]private float zoomMin;
    [SerializeField]private float zoomMax;
    
    
    
    //Translation
    private Vector3 newPosition;
    private IMoveInput moveInput;

    //Rotation
    private Quaternion newRotation;
    private IRotationInput rotationInput;
    
    //Zoom
    private Vector3 newZoom;
    private IZoomInput zoomInput;


    private void Awake() 
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;

        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = mainCam.transform.localPosition;

        //moveInput = GetComponent<IMoveInput>();
        moveInput = GetComponentInParent<IMoveInput>();
        rotationInput = GetComponentInParent<IRotationInput>();
        zoomInput = GetComponentInParent<IZoomInput>();
        
    }

    // Update is called once per frame
    void Update()
    {
        moveCamera();
        rotateCamera();
        zoomCamera();
    }

    private void moveCamera()
    {
        newPosition += movementSpeed * (transform.forward * moveInput.MoveDirection.y + transform.right * moveInput.MoveDirection.x);
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
    }

    private void rotateCamera()
    {
        newRotation *= Quaternion.Euler(Vector3.up * rotationInput.RotationDirection * rotationSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * rotationTime);
    }

    private void zoomCamera()
    {
        newZoom += zoomSpeed * zoomInput.ZoomDirection;
        newZoom = Vector3Util.ClampMinMax(newZoom, zoomMin, zoomMax);
        mainCam.transform.localPosition = Vector3.Lerp(mainCam.transform.localPosition, newZoom, Time.deltaTime * zoomTime);
    }

    
    
}
