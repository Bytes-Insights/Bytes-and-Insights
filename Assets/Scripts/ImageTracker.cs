using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ImageTracker : MonoBehaviour
{   
    public Vuforia.ImageTargetBehaviour imageTarget;
    private bool tracked = false;

    void Start()
    {
        if (!imageTarget)
        {
            imageTarget = gameObject.GetComponentInParent<Vuforia.ImageTargetBehaviour>();
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
        }
        else
        {
            tracked = false;
        }
    }
    
    public bool IsTracked() {
        return tracked;
    }
}
