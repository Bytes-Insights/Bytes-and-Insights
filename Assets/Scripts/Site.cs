using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.Linq;

public class Site : Subject
{
    public int networkVersion = 5;
    private Range range;

    private Vuforia.ImageTargetBehaviour imageTarget;
    private bool tracked = false;
    private float timer = 0.0f;

    //The number is random, but basically is capacity/second
    public float latency = 1500f;
    private float capacity;

    List<GameObject> potentialUsers = new List<GameObject>();
    List<GameObject> connectedUsers = new List<GameObject>();

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

    public void connectToSite(GameObject User, float userLoad){
        AddObserver(User);

        //Store how much time each user is connected
        potentialUsers.Add(User);

        capacity -= userLoad;
        NotifySingleObserver(User, true);
        notifyLatency();
    }

    public void disconnect(GameObject User){
        NotifySingleObserver(User, false);
        RemoveObserver(User);
        potentialUsers.Remove(User);
        notifyLatency();
    }

    private void notifyLatency(){
        List<GameObject> newConnectedUsers = new List<GameObject>();
        capacity = latency;

        for (int i = 1; i <= 5; i++) {
            List<GameObject> usersWithPriority = new List<GameObject>(connectedUsers);
            usersWithPriority.AddRange(potentialUsers);

            usersWithPriority = usersWithPriority
                .Where(user => user.GetComponent<User>().getPriority() == i)
                .Distinct()
                .ToList();

            foreach (GameObject user in usersWithPriority) {
                User userComponent = user.GetComponent<User>();
                float userCapacity = userComponent.getCapacity();

                capacity -= userCapacity;
                //Connect user
                if (capacity >= 0) {
                    newConnectedUsers.Add(user);
                    userComponent.setEmoji(true);
                } else {
                    break;
                }
            }

            if (capacity < 0) {
                break;
            }
        }

        //Disconnected users
        List<GameObject> potentialUsersNotInNewConnectedUsers = potentialUsers.Except(newConnectedUsers).ToList();
        foreach (GameObject user in potentialUsersNotInNewConnectedUsers) {
            User userComponent = user.GetComponent<User>();
            userComponent.setEmoji(false);
        }
    }
}