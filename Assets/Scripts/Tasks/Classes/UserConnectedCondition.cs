using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserConnectedCondition : SubtaskCondition
{
    public UserConnectedCondition(Subtask s){
        subtask = s;
    }

    override public bool checkCondition()
    {
        GameObject[] sites = GameObject.FindGameObjectsWithTag("Site_Controller");

        foreach (GameObject obj in sites)
        {
            Site controller = obj.GetComponent<Site>();
            Debug.Log(controller);
            if (controller && controller.AreUsersConnected())
            {
                isCompleted = true;
                break;
            }
        }

        return isCompleted;
    }
}
