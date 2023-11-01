using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtaskCondition : MonoBehaviour
{
    protected Subtask subtask;
    protected bool canBeCompleted = false;
    protected bool isCompleted = false;

    public void SetCanBeCompleted(bool canBeCompleted)
    {
        this.canBeCompleted = canBeCompleted;
    }

    protected void completeCondition(){
        isCompleted = true;
    }

    public bool getCompleted(){
        Debug.Log("Condition Completed");
        return canBeCompleted;
    }

    virtual public bool checkCondition(){
        return isCompleted;
    }
}
