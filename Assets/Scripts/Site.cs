using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.Linq;
using TMPro;

public class Site : Subject
{
    //Shader variables
    private MeshRenderer[] renderers;

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

        //Material Renderers from parent (User's Target GameObject)
        renderers = GetRenderersRecursively(transform.parent);
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
        connectedUsers.Remove(User);
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

        setCapacity();
    }

    private void setCapacity(){
        //Change text
        TextMeshPro text = transform.Find("Capacity").gameObject.GetComponent<TextMeshPro>();
        int percentage = 0;
        if(capacity < 0)
            percentage = 100;
        else
            percentage = (int)((latency-capacity) / latency * 100);

        text.text = percentage.ToString() + "%";

        float percentageNormalized = percentage / 100.0f;
        UpdateColorShift(percentage);
        // Change color
        if (percentageNormalized > 0.9f)
        {
            text.color = Color.red;
        }
        else if (percentageNormalized > 0.7f)
        {
            text.color = Color.Lerp(new Color(1.0f, 0.5f, 0.0f), Color.red, (percentageNormalized - 0.7f) / 0.2f);
        }
        else if (percentageNormalized > 0.5f)
        {
            text.color = Color.Lerp(Color.yellow, new Color(1.0f, 0.5f, 0.0f), (percentageNormalized - 0.5f) / 0.2f);
        }
        else
        {
            text.color = Color.green;
        }
    }

    private void UpdateColorShift(int percentage)
    {
        foreach (var renderer in renderers)
        {
            Material[] materials = renderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                 materials[i].SetInt("_LoadPercentage", percentage);
            }
        }
    }

    MeshRenderer[] GetRenderersRecursively(Transform parent)
    {
        // Initialize a list to store renderers.
        List<MeshRenderer> renderers = new List<MeshRenderer>();

        // Check if the current GameObject has a renderer, and add it to the list if it does.
        MeshRenderer renderer = parent.GetComponent<MeshRenderer>();
        if (renderer != null)
        {
            renderers.Add(renderer);
        }

        // Recursively check the children of the current GameObject.
        foreach (Transform child in parent)
        {
            renderers.AddRange(GetRenderersRecursively(child));
        }

        // Return the combined list of renderers.
        return renderers.ToArray();
    }
}