using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private Transform[] stacks;

    private Transform currentStack;
    private int currentStackNum = 0;
    private bool mouseDown = false;
    private Vector3 mousePressedPosition;

    void Start()
    {
        currentStack = stacks[currentStackNum];
    }
    void Update()
    {
        RotateCamera();
        SwitchCameraAnchor();
    }

    /// <summary>
    /// rotates the camera around the currently anchored tower via mouseclick
    /// </summary>
    private void RotateCamera()
    {
        if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
        }else if (mouseDown)
        {
            float spin = (mousePressedPosition - Input.mousePosition).x;
            
            if (spin > GameSettings.CAMERA_SPIN_CAP)
                spin = GameSettings.CAMERA_SPIN_CAP;
            else if (spin < -GameSettings.CAMERA_SPIN_CAP)
                spin = -GameSettings.CAMERA_SPIN_CAP;
            
            transform.RotateAround(currentStack.position,Vector3.up, spin * Time.deltaTime);
        }else if (Input.GetMouseButtonDown(0))
        {
            mouseDown = true;
            mousePressedPosition = Input.mousePosition;
        }
    }
    /// <summary>
    /// Switches between the positions of the towers via right or left arrow key
    /// </summary>
    private void SwitchCameraAnchor()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 distanceFromCurrentStack = transform.position - stacks[currentStackNum].transform.position;

            currentStackNum -= 1;
            if (currentStackNum < 0)
                currentStackNum = stacks.Length - 1;

            currentStack = stacks[currentStackNum];

            transform.position = stacks[currentStackNum].transform.position + distanceFromCurrentStack;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 distanceFromCurrentStack = transform.position - stacks[currentStackNum].transform.position;
            
            currentStackNum += 1;
            if (currentStackNum >= stacks.Length)
                currentStackNum = 0;

            currentStack = stacks[currentStackNum];
            
            transform.position = stacks[currentStackNum].transform.position + distanceFromCurrentStack;
        }
    }
}
