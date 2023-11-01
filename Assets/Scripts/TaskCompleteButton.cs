using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskCompleteButton : MonoBehaviour
{
    private LayerMask taskCompleteButtonLayer;

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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform a raycast to detect the object
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, taskCompleteButtonLayer))
            {
                // Check if the ray hit the GameObject this script is attached to
                if (hit.collider.gameObject == gameObject)
                {
                    onTouch();
                }
            }
        }
    }

    private void onTouch()
    {
        GameObject.Destroy(gameObject);
    }

}
