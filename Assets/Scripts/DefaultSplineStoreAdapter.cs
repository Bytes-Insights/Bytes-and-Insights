using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class DefaultSplineStoreAdapter : MonoBehaviour
{
    public SplineStore splineStore;

    void Start()
    {
        SplineContainer container = GetComponent<SplineContainer>();

        if (container == null || splineStore == null)
        {
            Debug.LogError("Incorrect configuration of DefaultSplineStoreAdapter.");
        }

        splineStore.SetSpline(container.Spline);
    }
}
