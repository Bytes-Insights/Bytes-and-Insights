using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Site : MonoBehaviour
{
    public int networkVersion = 5;
    private Range range;

    private Vuforia.ImageTargetBehaviour imageTarget;
    private bool tracked = false;

    void Start()
    {
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
}