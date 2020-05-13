using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class HexGridInputHandler : MonoBehaviour
{
    private IMouseInput mouseInput;
    private Camera mainCam;

    private void Awake() {
        
    }

    private void Start() {
        mouseInput = GetComponentInParent<IMouseInput>();
        mainCam = Camera.main;
    }

    private void Update() {
        
        handleLeftClick();
    }

    private void handleLeftClick ()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray inputRay = mainCam.ScreenPointToRay(mouseInput.MousePosition);
            RaycastHit hit;
            if (Physics.Raycast(inputRay, out hit))
            {
                TouchCell(hit.point);
            }
        }
    }

    void TouchCell (Vector3 position) {
        position = transform.InverseTransformPoint(position);
        Debug.Log("touched at " + position);
    }
}
