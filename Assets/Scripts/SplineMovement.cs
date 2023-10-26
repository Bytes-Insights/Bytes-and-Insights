using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class SplineMovement : MonoBehaviour
{
    public SplineContainer container;
    public float speed = 0.01f;
    public bool loop = true;
    
    private float splineAlpha = 0f;

    private void Update()
    {
        Spline spline = container.Spline;

        if (spline != null)
        {
            if (splineAlpha <= 1f)
            {
                Vector3 position = spline.EvaluatePosition(splineAlpha);
                Vector3 tangent = spline.EvaluateTangent(splineAlpha);
                tangent = tangent.normalized; // Tangent carries magnitude...

                transform.localPosition = position;

                Quaternion targetRotation = Quaternion.LookRotation(tangent, Vector3.up);

                transform.rotation = targetRotation;

                splineAlpha += speed * Time.deltaTime;
            }
            else if (loop)
            {
                splineAlpha = 0f;
            }
        }
    }
}
