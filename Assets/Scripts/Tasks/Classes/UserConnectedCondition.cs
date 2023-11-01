using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserConnectedCondition : SubtaskCondition
{
    public UserConnectedCondition(Subtask s){
        subtask = s;
        canBeCompleted = false;
    }

    public bool checkCondition()
    {
        if (!canBeCompleted && subtask.getCompleted())
        {
            return false;
        }

        GameObject[] sites = GameObject.FindGameObjectsWithTag("Site_Controller");

        foreach (GameObject obj in sites)
        {
            Site controller = obj.GetComponent<Site>();

            if (controller && controller.AreUsersConnected())
            {
                isCompleted = true;
                break;
            }
        }

        return isCompleted;
    }
}
