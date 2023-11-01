using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtaskCondition : MonoBehaviour
{
    protected Subtask subtask;
    protected bool canBeCompleted = false;

    protected void SetCanBeCompleted(bool canBeCompleted)
    {
        this.canBeCompleted = canBeCompleted;
    }

    protected void completeSubtask(){
        subtask.setCompleted(true);
    }
}
