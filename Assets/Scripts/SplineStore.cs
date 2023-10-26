using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class SplineStore : MonoBehaviour
{
    private Spline spline;

    public Spline GetSpline()
    {
        return spline;
    }

    public void SetSpline(Spline spline)
    {
        this.spline = spline;
    }
}
