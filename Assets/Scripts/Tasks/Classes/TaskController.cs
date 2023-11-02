using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskController : MonoBehaviour
{
    private int _currentTask = 0;
    private List<Task> _tasks = new List<Task>();

    TextMeshPro textMeshPro;

    public GameObject _billboard;
    public GameObject _task0a;
    public GameObject _task0b;
    public GameObject _task1;
    public GameObject _task2;
    public GameObject _task3;
    private GameObject subtaskContainer;
    public GameObject _chibi1;
    public GameObject _chibi2;
    public GameObject _chibi3;
    public GameObject _chibi4;
    public GameObject _chibi5;

    public TaskCompleteButton _completeButton1;
    public TaskCompleteButton _completeButton2;
    public TaskCompleteButton _completeButton3;

    public SplineMovement _helicopterSpline;
    public User _helicopterUser;
   
    private bool stopcheck = false;

    void Start(){

        //Task 0a
        /*string subtask0a_1_description = "Frame in the camera the entire map to see the city";
        Subtask task0a_subtask1 = new Subtask(subtask0a_1_description);
        //Condition for subtask 1
        SiteScannedCondition subtask0a_1_condition1 = new SiteScannedCondition(task0a_subtask1);
        SubtaskCondition[] task0a_subtask1_conditions = {subtask0a_1_condition1};
        task0a_subtask1.setConditions(task0a_subtask1_conditions);

        //Creation of subtask array
        Subtask[] task0a_subtasks = {task0a_subtask1};

        //Creation of task 0a
        string task0a_description = "Make the virtual city appear!";
        Task task0a = new Task(task0a_description, task0a_subtasks, _task0a);

        //Add to Task List, add observer and activate gameobject
        _tasks.Add(task0a);
        task0a.OnComplete += OnTaskCompleted;
        _task0a.SetActive(false);*/
        /*
        //Task 0b
        string subtask0b_1_description = "Scan a target";
        Subtask task0b_subtask1 = new Subtask(subtask0b_1_description);
        SiteScannedCondition subtask0b_1_condition1 = new SiteScannedCondition(task0b_subtask1);
        SubtaskCondition[] task0b_subtask1_conditions = {subtask0b_1_condition1};
        task0b_subtask1.setConditions(task0b_subtask1_conditions);
        Subtask[] task0b_subtasks = {task0b_subtask1};
        string task0b_description = "Make a site appear!";
        Task task0b = new Task(task0b_description, task0b_subtasks, _task0b);
        _tasks.Add(task0b);
        //task0b.OnComplete += OnTaskCompleted;
        _task0b.SetActive(false);

        //Task 1
        string subtask1_1_description = "Activate coverage layer";
        Subtask task1_subtask1 = new Subtask(subtask1_1_description);
        RangeLayerActiveCondition subtask1_1_condition1 = new RangeLayerActiveCondition(task1_subtask1);
        SubtaskCondition[] task1_subtask1_conditions = {subtask1_1_condition1};
        task1_subtask1.setConditions(task1_subtask1_conditions);

        string subtask1_2_description = "Bring a site nearby the person";
        Subtask task1_subtask2 = new Subtask(subtask1_2_description);
        UserConnectedCondition subtask1_2_condition1 = new UserConnectedCondition(task1_subtask2);
        SubtaskCondition[] task1_subtask2_conditions = {subtask1_2_condition1};
        task1_subtask2.setConditions(task1_subtask2_conditions);

        string task1_description = "Give internet to that guy in the park!";
        Subtask[] task1_subtasks = {task1_subtask1, task1_subtask2};
        Task task1 = new Task(task1_description, task1_subtasks, _task1);
        _tasks.Add(task1);
        //task1.OnComplete += OnTaskCompleted;
        _task1.SetActive(false);
        
        

        //Task 2
        string subtask2_1_description = "Don't let the helicopter disconnect from the internet";
        Subtask task2_subtask1 = new Subtask(subtask2_1_description);
        HelicopterConnectionCondition subtask2_1_condition1 = new HelicopterConnectionCondition(task2_subtask1, _helicopterSpline, _helicopterUser);
        SubtaskCondition[] task2_subtask1_conditions = {subtask2_1_condition1};
        task2_subtask1.setConditions(task2_subtask1_conditions);

        Subtask[] task2_subtasks = {task2_subtask1};
        string task2_description = "Don't let the helicopter disconnect from the internet!";
        Task task2 = new Task(task2_description, task2_subtasks, _task2);
        _tasks.Add(task2);
        //task2.OnComplete += OnTaskCompleted;
        _task2.SetActive(false);
*/

        GameObject button = GameObject.FindGameObjectsWithTag("Button_Connection")[0];
        ConnectivityLayerController controller = button.GetComponent<ConnectivityLayerController>();
        controller.makeConnectionButtonAvailable();

        //Task 3
        GameObject[] _task3Chibis = {_chibi1, _chibi2, _chibi3, _chibi4, _chibi5};
        string subtask3_1_description = "Provide internet to everyone";
        Subtask task3_subtask1 = new Subtask(subtask3_1_description);
        AllUsersConnectedCondition task3_subtask1_condition1 = new AllUsersConnectedCondition(task3_subtask1, _task3Chibis);
        SubtaskCondition[] task3_subtask1_conditions = {task3_subtask1_condition1};
        task3_subtask1.setConditions(task3_subtask1_conditions);

        Subtask[] task3_subtasks = {task3_subtask1};
        string task3_description = "Give internet everyone in the park!";
        Task task3 = new Task(task3_description, task3_subtasks, _task3);
        _tasks.Add(task3);
        //task3.OnComplete += OnTaskCompleted;
        _task3.SetActive(false);

        _tasks[_currentTask].getGameObject().SetActive(true);
        textMeshPro = _billboard.GetComponent<TextMeshPro>();
        textMeshPro.text = _tasks[_currentTask].getDescription();


        _completeButton1.gameObject.SetActive(false);
        _completeButton2.gameObject.SetActive(false);
        _completeButton3.gameObject.SetActive(false);
    }

    void Update()
    {
        if(_currentTask < _tasks.Count){
            if (stopcheck==false) {
                checkTask();
            } else {

            /*switch(_currentTask){           //switch to select with button to enable
                case 0:
                _completebutton1.gameObject.SetActive(true);
                //I dont know how to subscribe to the event in he other class
                break;

                case 1:
                _completebutton2.gameObject.SetActive(true);
                //I dont know how to subscribe to the event in he other class
                break;

                case 2;
                _completebutton3.gameObject.SetActive(true);
                //I dont know how to subscribe to the event in he other class
                break
            }*/

            }
        }
    }
    
    void OnTaskCompleted(){
        Debug.Log("Completed");

        _completeButton1.gameObject.SetActive(false);
        _completeButton2.gameObject.SetActive(false);
        _completeButton3.gameObject.SetActive(false);

        //Deactivate task
        _tasks[_currentTask].getGameObject().SetActive(false);
        //Increment task
        _currentTask++;
        
        if(_currentTask >= _tasks.Count){
            textMeshPro.text = "Explore the world!";
            return;
        }

        //Show task description in billboard
        textMeshPro.text = _tasks[_currentTask].getDescription();

        //Activate new task
        _tasks[_currentTask].getGameObject().SetActive(true);

        if(_currentTask > 0){
            GameObject button = GameObject.FindGameObjectsWithTag("Button_Ranges")[0];
            RangeLayerController controller = button.GetComponent<RangeLayerController>();
            controller.makeRangeButtonAvailable();
        }

        if(_currentTask > 1){
            GameObject button = GameObject.FindGameObjectsWithTag("Button_Connection")[0];
            ConnectivityLayerController controller = button.GetComponent<ConnectivityLayerController>();
            controller.makeConnectionButtonAvailable();
        }
    }

    private void checkTask(){
        if(_tasks[_currentTask].checkSubtasks()){
            stopcheck=true;

            if (_currentTask == 0) {
                _completeButton1.gameObject.SetActive(true);
                _completeButton1.OnExecute += OnTaskCompleted;
            }



            if (_currentTask == 1) {
                _completeButton2.gameObject.SetActive(true);
                _completeButton2.OnExecute += OnTaskCompleted;
            }



            if (_currentTask == 3) {
                _completeButton3.gameObject.SetActive(true);
                _completeButton3.OnExecute += OnTaskCompleted;
            }
            //OnTaskCompleted();
        }
    }
}
