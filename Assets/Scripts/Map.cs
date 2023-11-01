using System.Collections;
using System.Collections.Generic;
using Vuforia;
using UnityEngine;

public class Map : Subject
{

    private Vuforia.ImageTargetBehaviour imageTarget;
    private bool tracked = false;

    // Start is called before the first frame update
    void Start()
    {
        setSubjectName("Map");
        imageTarget = gameObject.GetComponentInParent<Vuforia.ImageTargetBehaviour>();

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

}
