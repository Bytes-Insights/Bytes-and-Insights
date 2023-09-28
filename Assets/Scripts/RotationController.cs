using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    public ExplanationController explanationController;
    private GameObject canvas;
    private bool tracker = false;
    
    // Start is called before the first frame update
    void Start()
    {
        canvas = transform.Find("Canvas - RotationController").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
        {
            if(!tracker){
                canvas.SetActive(true);
                explanationController.Hide();
                tracker = true;
            }         
        }else{
            if(tracker){
                canvas.SetActive(false);
                tracker = false;
            }
        }
    }

}
