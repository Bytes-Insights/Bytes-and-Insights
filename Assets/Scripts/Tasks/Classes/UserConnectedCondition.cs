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
        Debug.Log("Called");
        foreach (GameObject obj in sites)
        {
            Site controller = obj.GetComponent<Site>();
            
            if (controller && controller.AreUsersConnected())
            {
                Debug.Log("YESSSS!!");
                isCompleted = true;
                break;
            }
        }

        return isCompleted;
    }
}
