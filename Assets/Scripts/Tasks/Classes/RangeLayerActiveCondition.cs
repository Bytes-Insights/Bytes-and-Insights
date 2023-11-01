using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeLayerActiveCondition : SubtaskCondition
{
    public RangeLayerActiveCondition(Subtask s){
        subtask = s;
        canBeCompleted = false;
    }

    override public bool checkCondition()
    {
        if (!canBeCompleted && subtask.getCompleted())
        {
            return false;
        }

        GameObject button = GameObject.FindGameObjectsWithTag("Button_Ranges")[0];
        RangeLayerController controller = button.GetComponent<RangeLayerController>();

        if (controller && controller.getIsActive())
        {
            Debug.Log("YES");
            isCompleted = true;
        }
        

        return isCompleted;
    }

}
