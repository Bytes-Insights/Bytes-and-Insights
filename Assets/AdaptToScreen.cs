using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptToScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RectTransform panelRectTransform = GetComponent<RectTransform>();
        panelRectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
