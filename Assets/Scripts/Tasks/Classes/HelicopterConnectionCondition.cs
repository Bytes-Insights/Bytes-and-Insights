using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterConnectionCondition : MonoBehaviour
{
    public Subtask subtask;
    public SplineMovement helicopterMovement;
    public User helicopterUser;

    private bool canBeCompleted = false;
    private bool trackingLoop = false;

    void Start()
    {
        if (helicopterMovement != null)
        {
            helicopterMovement.OnLoop += HandleLoop; 
        }    
    }

    void HandleLoop()
    {
        if (!canBeCompleted && subtask.getCompleted())
        {
            return;
        }

        if (trackingLoop)
        {
            subtask.setCompleted(true);
            return;
        }


        trackingLoop = true;
    }

    void Update()
    {
        if (!canBeCompleted && subtask.getCompleted())
        {
            return;
        }

        if (!helicopterUser.IsConnected() && helicopterMovement.IsWithinOpaqueSegment())
        {
            trackingLoop = false;
        }
    }

    void SetCanBeCompleted(bool canBeCompleted)
    {
        this.canBeCompleted = canBeCompleted;
    }
}
