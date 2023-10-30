using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBackgroundScaler : MonoBehaviour
{
    public GameObject plane;
    public float padding = 0.5F;

    void Start()
    {
        Match();
    }

    void Match()
    {
        Rect sourceBounds = GetComponent<RectTransform>().rect;

        plane.transform.localScale = new Vector3(sourceBounds.size.x / 10 + (padding / 10) * 2, 1, sourceBounds.size.y / 10 + (padding / 10) * 2);
    }
}
