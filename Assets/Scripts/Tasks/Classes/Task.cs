using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    Subtask[] _subtasks;

    // Start is called before the first frame update
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
            //Resolve task
        }
    }
}
