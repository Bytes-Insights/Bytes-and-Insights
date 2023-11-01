using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterConnectionCondition : SubtaskCondition
{
    public SplineMovement helicopterMovement;
    public User helicopterUser;

    private bool trackingLoop = false;

    public HelicopterConnectionCondition(Subtask s, SplineMovement movement, User user){
        subtask = s;
        canBeCompleted = false;
        helicopterMovement = movement;
        helicopterUser = user;
    }

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
