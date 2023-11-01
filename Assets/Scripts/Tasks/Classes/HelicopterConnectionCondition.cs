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
        helicopterMovement.OnLoop += HandleLoop; 
    }

    void HandleLoop()
    {
        if (!canBeCompleted && subtask.getCompleted())
        {
            return;
        }

        if (trackingLoop)
        {
            completeCondition();
            return;
        }


        trackingLoop = true;
    }

    override public bool checkCondition()
    {
        if (!canBeCompleted && subtask.getCompleted())
        {
            return false;
        }

        if (!helicopterUser.IsConnected() && helicopterMovement.IsWithinOpaqueSegment())
        {
            trackingLoop = false;
        }

        return isCompleted;
    }

    void SetCanBeCompleted(bool canBeCompleted)
    {
        this.canBeCompleted = canBeCompleted;
    }
}
