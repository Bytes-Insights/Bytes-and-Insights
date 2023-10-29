using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Site : Subject
{
    public int networkVersion = 5;
    private Range range;

    private Vuforia.ImageTargetBehaviour imageTarget;
    private bool tracked = false;
    private float timer = 0.0f;

    //The number is random, but basically is capacity/second
    public float latency = 5000;
    private float capacity;

    IDictionary<GameObject, float> connectedUsers = new Dictionary<GameObject, float>();
    IDictionary<GameObject, float> connectionTime = new Dictionary<GameObject, float>();

    void Start()
    {
        setSubjectName("Site");
        capacity = latency;
        range = GetComponent<Range>();
        imageTarget = gameObject.GetComponentInParent<Vuforia.ImageTargetBehaviour>();


        if (this.networkVersion == 4)
        {
            // this.GetComponent<MeshRenderer>().material.color = new Color(0.5566038F, 0.5566038F, 0, 1);
        }

        if (imageTarget)
        {
            imageTarget.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    void Update(){
        timer += Time.deltaTime;
        foreach(KeyValuePair<GameObject, float> res in connectedUsers){
            //Check if user connection time has been completed
            if(timer - connectionTime[res.Key] > res.Value){
                NotifySingleObserver(res.Key, false);
                RemoveObserver(res.Key);
            }
        }
    }

    void OnTargetStatusChanged(ObserverBehaviour observerbehavour, TargetStatus status)
    {
        if ((status.Status == Status.TRACKED) && status.StatusInfo == StatusInfo.NORMAL)
        {
            tracked = true;
        } else
        {
            tracked = false;
        }
    }

    public bool IsTracked()
    {
        return tracked;
    }

    public Range GetRange()
    {
        return range;
    }

    public void connectToSite(GameObject User, float userLoad, float userConnectionTime){
        if(capacity - userLoad > 0){
            AddObserver(User);
            
            //Store at what time the user connected
            connectionTime.Add(User, timer);

            //Store how much time each user is connected
            connectedUsers.Add(User, userConnectionTime);

            capacity -= userLoad;
            NotifySingleObserver(User, true);
        }
    }
}