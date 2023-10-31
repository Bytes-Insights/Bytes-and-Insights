using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    string _description;
    Subtask[] _subtasks;
    public delegate void ExecuteEventHandler();
    public event ExecuteEventHandler OnComplete;

    public Task(string description, Subtask[] subtasks){
        _description=description;
        _subtasks=subtasks;
    }

    void Start()
    {
        foreach(Subtask task in _subtasks){
            task.OnCompleteStateChange += onSubtaskUpdate;
        }
    }

    void onSubtaskUpdate(){
        bool result = true;
        foreach(Subtask task in _subtasks){
            result = task.getCompleted();
            if(!result)
                break;
        }

        if(result){
            OnComplete.Invoke();
        }
    }

    public string getDescription(){
        return _description;
    }
}
