using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class User : MonoBehaviour
{
    // private Range range;
    private GameObject[] potentialTargets;
    private LineRenderer renderer;

    //TextBox Controller variables
    private GameObject canvas;
    private textboxController textboxController;

    private Vuforia.ImageTargetBehaviour imageTarget;
    private bool tracked = false;

    void Start()
    {
        potentialTargets = GameObject.FindGameObjectsWithTag("Site");
       //  range = GetComponent<Range>();
        renderer = GetComponent<LineRenderer>();
        renderer.enabled = false;

        //TextBox Controller variables definition
        canvas = GameObject.Find("Canvas");
        textboxController = (textboxController) canvas.GetComponent(typeof(textboxController));

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
        }
        else
        {
            this.renderer.enabled = false;
            tracked = false;
        }
    }

    void Update()
    {
        if (!tracked)
        {
            this.renderer.enabled = false;
            return;
        }

        Site eligibleTarget = null;
        Transform eligibleTargetTransform = null;
        double lastDist = double.MaxValue;

        foreach (GameObject potentialTarget in potentialTargets)
        {
            Site site = potentialTarget.GetComponent<Site>();

            if (!site.IsTracked()) continue;

            //float usrMaxRange = range.range;
            float siteMaxRange = site.GetRange().range;
            float requiredRange = siteMaxRange; //Mathf.Min(usrMaxRange, siteMaxRange);

            GameObject referencePoint = FindChildWithTag(potentialTarget.transform, "AntennaReferencePoint");
            Transform targetTransform = referencePoint ? referencePoint.transform : potentialTarget.transform;

            double dist = (targetTransform.position - this.transform.position).magnitude;
            if (dist > requiredRange) continue;

            if (eligibleTarget == null ||
                eligibleTarget.networkVersion < site.networkVersion ||
                (eligibleTarget.networkVersion == site.networkVersion && dist < lastDist))
            {
                eligibleTarget = site;
                eligibleTargetTransform = targetTransform;
                lastDist = dist;
            }
        }


        if (eligibleTarget != null)
        {
            renderer.enabled = true;
            renderer.SetPosition(0, transform.position);
            renderer.SetPosition(1, eligibleTargetTransform.position);
            textboxController.textboxBeamformingIntroduction();

        }
        else
        {
            renderer.enabled = false;
        }
    }
    GameObject FindChildWithTag(Transform parent, string tag)
    {
        foreach (Transform child in parent)
        {
            if (child.CompareTag(tag))
            {
                return child.gameObject;
            }
        }
        return null;
    }
}