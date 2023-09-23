using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeToScreen : MonoBehaviour
{
    private RectTransform panelRectTransform;
    // Start is called before the first frame update
    void Start()
    {
        panelRectTransform = GetComponent<RectTransform>();

        if (panelRectTransform == null)
        {
            Debug.LogError("No RectTransform found on this GameObject.");
            return;
        }

        ResizePanel();
    }

    private void ResizePanel()
    {
        float screenHeight = Screen.height;
        panelRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, screenHeight);
    }
}
