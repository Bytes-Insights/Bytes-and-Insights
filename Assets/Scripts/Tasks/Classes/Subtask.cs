using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subtask : MonoBehaviour
{
    public string _description;
    public bool _completed;
    private SubtaskCondition[] _subtasksConditions;
    public delegate void ExecuteEventHandler();
    public event ExecuteEventHandler OnCompleteStateChange;

    public Subtask(string description, SubtaskCondition[] subtasksConditions){
        _completed=false;
        _description=description;
        _subtasksConditions=subtasksConditions;
    }

    public bool getCompleted(){
        return _completed;
    }
    public string getDescription(){
        return _description;
    }
    public void setCompleted(bool completed){
        _completed = completed;
        OnCompleteStateChange.Invoke();
    }
}
