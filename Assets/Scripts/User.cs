using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    // private Range range;
    private GameObject[] potentialTargets;
    private LineRenderer renderer;

    void Start()
    {
        potentialTargets = GameObject.FindGameObjectsWithTag("Site");
       //  range = GetComponent<Range>();
        renderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        Site eligibleTarget = null;
        double lastDist = double.MaxValue;

        foreach (GameObject potentialTarget in potentialTargets)
        {
            Site site = potentialTarget.GetComponent<Site>();
            //float usrMaxRange = range.range;
            float siteMaxRange = site.GetRange().range;
            float requiredRange = siteMaxRange; //Mathf.Min(usrMaxRange, siteMaxRange);

            double dist = (potentialTarget.transform.position - this.transform.position).magnitude;
            if (dist > requiredRange) continue;

            if (eligibleTarget == null ||
                eligibleTarget.networkVersion < site.networkVersion ||
                (eligibleTarget.networkVersion == site.networkVersion && dist < lastDist))
            {
                eligibleTarget = site;
                lastDist = dist;
            }
        }


        if (eligibleTarget != null)
        {
            renderer.enabled = true;
            renderer.SetPosition(0, transform.position);
            renderer.SetPosition(1, eligibleTarget.transform.position);
        }
        else
        {
            renderer.enabled = false;
        }
    }
}