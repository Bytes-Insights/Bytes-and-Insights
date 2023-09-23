using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptChildrenToWidth : MonoBehaviour
{
    public float margin = 10f; // Adjust the margin as needed
    // Start is called before the first frame update
    void Start()
    {
        float screenHeight = Screen.height;
        RectTransform referenceRectTransform = GetComponent<RectTransform>();
        referenceRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, screenHeight);
        float referenceWidth = referenceRectTransform.rect.width;
        float availableWidth = referenceWidth - 2 * margin;

        // Iterate through all child objects
        foreach (Transform child in transform)
        {
            // Get the RectTransform of the child
            RectTransform childRectTransform = child.GetComponent<RectTransform>();

            if (childRectTransform != null)
            {
                // Set the width of the childRectTransform equally as the referenceRectTransform
                childRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, availableWidth);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
