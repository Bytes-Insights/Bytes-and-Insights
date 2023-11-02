using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task
{
    string _description;
    GameObject _taskGameObject;
    Subtask[] _subtasks;

    public Task(string description, Subtask[] subtasks, GameObject taskGameObject){
        _description=description;
        _subtasks=subtasks;
        _taskGameObject = taskGameObject;
    }

    /*void onSubtaskUpdate(){
        bool result = true;
        foreach(Subtask task in _subtasks){
            result = task.getCompleted();
            if(!result)
                break;
        }

        if(result){
            OnComplete.Invoke();
        }
    }*/

    public string getDescription(){
        return _description;
    }

    public GameObject getGameObject(){
        return _taskGameObject;
    }

    public bool checkSubtasks(){
        bool result = true;
        Debug.Log("TASK EVALUATION");
        Debug.Log(_subtasks.Length);
        foreach(Subtask subtask in _subtasks){
            if(!subtask.checkConditions()){
                result=false;
                break;
            }
        }
        return result;
    }
}
