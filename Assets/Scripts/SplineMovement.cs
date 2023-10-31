using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class SplineMovement : MonoBehaviour
{
    public SplineContainer container;
    public float speed = 0.01f;
    public bool loop = true;
    public float fadeInPoint = 0.2F;
    public float fadeOutPoint = 0.8F;

    private float splineAlpha = 0f;

    private void Start()
    {
        SetOpacity(0.1F);
    }

    private float Clamp(float value)
    {
        return Mathf.Min(1, Mathf.Max(0, value));
    }

    public float CalcOpacity(float alpha)
    {
        // Ramp up with ease-in.
        float easeIn = Mathf.Pow(Clamp(alpha / fadeInPoint), 2);

        // Get a normalized clamped value in the tail of the curve.
        float normalizedTailValue = Clamp((alpha - fadeOutPoint) / (1 - fadeOutPoint));

        // Ease-out.
        float easeOut = 1 - normalizedTailValue * (2 - normalizedTailValue);

        return Mathf.Min(easeIn, easeOut);
    }

    private void Update()
    {
        Spline spline = container.Spline;

        if (spline != null)
        {
            SetOpacity(CalcOpacity(splineAlpha));

            if (splineAlpha <= 1f)
            {
                Vector3 position = spline.EvaluatePosition(splineAlpha);
                Vector3 tangent = spline.EvaluateTangent(splineAlpha);
                tangent = tangent.normalized; // Tangent carries magnitude...

                transform.localPosition = position;

                Quaternion targetRotation = Quaternion.LookRotation(tangent, Vector3.up);

                transform.localRotation = targetRotation;

                splineAlpha += speed * Time.deltaTime;
            }
            else if (loop)
            {
				splineAlpha = 0f;
            }
        }
    }



    public void SetOpacity(float newOpacity)
    {
        MeshRenderer[] childRenderers = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer renderer in childRenderers)
        {
            foreach (Material mat in renderer.materials)
            {
                Color tempColor = mat.color;
                tempColor.a = newOpacity;
                mat.color = tempColor;
            }
        }
    }
}
