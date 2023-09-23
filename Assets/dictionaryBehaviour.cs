using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dictionaryBehaviour : MonoBehaviour
{
    private RectTransform panelRectTransform;
    public float margin = 10f; // Adjust the margin as needed
    // Start is called before the first frame update
    void Start()
    {
        panelRectTransform = GetComponent<RectTransform>();
        panelRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height);    
        panelRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width);  

        // Iterate through all child objects
        foreach (Transform child in transform)
        {
            // Get the RectTransform of the child
            RectTransform childRectTransform = child.GetComponent<RectTransform>();

            if (childRectTransform != null)
            {
                // Set the width of the childRectTransform equally as the referenceRectTransform
                childRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width);
                childRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height); 
            }

            float availableWidth = Screen.width - 2 * margin;

            foreach (Transform grandchild in child.transform){
                RectTransform grandchildRectTransform = grandchild.GetComponent<RectTransform>();
                if (grandchildRectTransform != null)
                {
                    // Set the width of the childRectTransform equally as the referenceRectTransform
                    grandchildRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, availableWidth);
                }
            }

        }
        }

    public void DeactivateDictionary()
    {
        foreach (Transform child in transform)
        {
            if (child.CompareTag("DictionaryPanel"))
            {
                continue; // Skip this child
            }
            child.gameObject.SetActive(false);
        }
        //Deactivate self
        transform.gameObject.SetActive(false);
    }
}
