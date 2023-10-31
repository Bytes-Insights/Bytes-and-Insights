using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subtask : MonoBehaviour
{
    public string _description;
    public bool _completed;

    public delegate void ExecuteEventHandler();
    public event ExecuteEventHandler OnCompleteStateChange;

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
