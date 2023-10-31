using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskController : MonoBehaviour
{
    private int _currentTask = 0;
    private Task[] _tasks;

    public GameObject _task0a;
    public GameObject _task0b;
    public GameObject _task1;
    public GameObject _task2;
    public GameObject _task3;

    void Start(){

        //Task 0a
        string subtask0a_1_description = "Frame in the camera the entire map to see the city";
        Subtask task0a_subtask1 = new Subtask(subtask0a_1_description);
        Subtask[] task0a_subtasks = {task0a_subtask1};
        string task0a_description = "Make the virtual city appear!";
        Task task0a = new Task(task0a_description, task0a_subtasks, _task0a);
        task0a.OnComplete += OnTaskCompleted;

        //Task 0b
        string subtask0b_1_description = "Scan a target";
        Subtask task0b_subtask1 = new Subtask(subtask0b_1_description);
        Subtask[] task0b_subtasks = {task0b_subtask1};
        string task0b_description = "Make a site appear!";
        Task task0b = new Task(task0b_description, task0b_subtasks, _task0b);
        task0b.OnComplete += OnTaskCompleted;

        //Task 1
        string subtask1_1_description = "Activate coverage layer";
        string subtask1_2_description = "Place a site nearby the park";
        Subtask task1_subtask1 = new Subtask(subtask1_1_description);
        Subtask task1_subtask2 = new Subtask(subtask1_2_description);
        Subtask[] task1_subtasks = {task1_subtask1, task1_subtask2};
        string task1_description = "Give internet to that guy in the park!";
        Task task1 = new Task(task1_description, task1_subtasks, _task1);
        task1.OnComplete += OnTaskCompleted;

        //Task 2
        string subtask2_1_description = "Don't let the helicopter disconnect from the internet";
        Subtask task2_subtask1 = new Subtask(subtask2_1_description);
        Subtask[] task2_subtasks = {task2_subtask1};
        string task2_description = "Give internet to the helicopter!";
        Task task2 = new Task(task2_description, task2_subtasks, _task2);
        task2.OnComplete += OnTaskCompleted;

        //Task 3
        string subtask3_1_description = "Give inter to guy number 1";
        string subtask3_2_description = "Give inter to guy number 2";
        string subtask3_3_description = "Give inter to guy number 3";
        Subtask task3_subtask1 = new Subtask(subtask3_1_description);
        Subtask task3_subtask2 = new Subtask(subtask3_2_description);
        Subtask task3_subtask3 = new Subtask(subtask3_3_description);
        Subtask[] task1_subtasks = {task3_subtask1, task3_subtask2, task3_subtask3};
        string task3_description = "Give internet everyone in the park!";
        Task task3 = new Task(task3_description, task3_subtasks, _task3);
        task3.OnComplete += OnTaskCompleted;

        _tasks[_currentTask].getGameObject().SetActive(true);
    }
    
    void OnTaskCompleted(){
        //Show task description in billboard
        

        //Deactivate task
        _tasks[_currentTask].getGameObject().SetActive(false);

        //Increment task
        _currentTask++;

        //Activate new task
        _tasks[_currentTask].getGameObject().SetActive(true);
    }
}
