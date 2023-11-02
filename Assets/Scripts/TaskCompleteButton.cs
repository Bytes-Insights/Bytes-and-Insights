using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskCompleteButton : MonoBehaviour
{
    private LayerMask taskCompleteButtonLayer;
    public delegate void ExecuteEventHandler();
    public event ExecuteEventHandler OnExecute;
    private bool executed = false;

    void Start()
    {
        //Initialization of private variables
        taskCompleteButtonLayer = LayerMask.GetMask("TaskComplete");

    }

    void Update()
    {

        // Check for touch or click input
        if (Input.GetMouseButtonDown(0)) // 0 represents the left mouse button (or touch input)
        {
            //EventProgram press = new EventProgram();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform a raycast to detect the object
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, taskCompleteButtonLayer))
            {
                // Check if the ray hit the GameObject this script is attached to
                if (hit.collider.gameObject == gameObject)
                {
                    //string result = press.OnButtonPressEvent(); for event
                    onTouch();
                }
            }
        }
    } 

    private void onTouch()
    {
        Debug.Log("onTeach");
        if (!executed) {
            executed = true;
            Debug.Log("HEY I HAVE BEEN TOUCHED");
            OnExecute.Invoke();
            GameObject.Destroy(gameObject);
        }
    }
}
