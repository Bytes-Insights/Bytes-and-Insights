using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiteScannedCondition : SubtaskCondition
{
    public SiteScannedCondition(Subtask s){
        subtask = s;
        canBeCompleted = false;
    }

    override public bool checkCondition()
    {
        if (!canBeCompleted && subtask.getCompleted())
        {
            return false;
        }

        GameObject[] sites = GameObject.FindGameObjectsWithTag("Site_Controller");

        foreach (GameObject obj in sites)
        {
            Site controller = obj.GetComponent<Site>();

            if (controller && controller.IsTracked())
            {
                isCompleted = true;
                break;
            }
        }

        return isCompleted;
    }

}
