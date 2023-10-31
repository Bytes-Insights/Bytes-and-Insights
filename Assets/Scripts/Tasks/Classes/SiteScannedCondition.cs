using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiteScannedCondition : MonoBehaviour
{
    public Subtask subtask;
    public bool canBeCompleted = false;

    void Update()
    {
        if (!canBeCompleted && subtask.getCompleted())
        {
            return;
        }

        GameObject[] sites = GameObject.FindGameObjectsWithTag("Site_Controller");

        foreach (GameObject obj in sites)
        {
            Site controller = obj.GetComponent<Site>();

            if (controller && controller.IsTracked())
            {
                subtask.setCompleted(true);
                return;
            }
        }
    }

    void SetCanBeCompleted(bool canBeCompleted)
    {
        this.canBeCompleted = canBeCompleted;
    }
}
