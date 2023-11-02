using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllUsersConnectedCondition : SubtaskCondition
{
    private GameObject[] users;

    public AllUsersConnectedCondition(Subtask s, GameObject[] objects){
        subtask = s;
        users = objects;
    }



    override public bool checkCondition()
    {
        bool result = true;
        foreach (GameObject user in users)
        {
            if(!user.GetComponent<User>().getConnected()){
                result = false;
                break;
            }
        }
        return result;
    }
}
