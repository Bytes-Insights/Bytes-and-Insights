using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subtask
{
    private string _description;
    private bool _completed;
    private SubtaskCondition[] _subtasksConditions;

    public Subtask(string description){
        _completed=false;
        _description=description;
    }

    public bool getCompleted(){
        return _completed;
    }
    public string getDescription(){
        return _description;
    }
    public void setConditions(SubtaskCondition[] subtasksConditions){
        _subtasksConditions=subtasksConditions;
    }
    public void setCompleted(bool completed){
        _completed = completed;
    }
    public void conditionCompleted(){
        bool result = true;
        foreach(SubtaskCondition condition in _subtasksConditions){
            if(!condition.getCompleted()){
                result = false;
                break;
            }
        }
        Debug.Log(result);
        if(result)
            setCompleted(true);
    }
    public bool checkConditions(){
        bool result = true;
        Debug.Log(_subtasksConditions);
        foreach(SubtaskCondition condition in _subtasksConditions){
            if(!condition.checkCondition()){
                result = false;
                break; 
            }
        }
        return result;
    }
}
