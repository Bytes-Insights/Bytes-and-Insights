using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    private GameObject canvas;
    private GameObject[] temporarilyHiddenCanvases;
    private bool[] hiddenCanvasesActiveStatus;
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
                deactivateCanvas();
                tracker = true;
            }         
        }else{
            if(tracker){
                canvas.SetActive(false);
                activateCanvas();
                tracker = false;
            }
        }
    }

    void deactivateCanvas(){
        temporarilyHiddenCanvases = GameObject.FindGameObjectsWithTag("Canvas");
        hiddenCanvasesActiveStatus = new bool[temporarilyHiddenCanvases.Length];

        for(int i = 0; i < temporarilyHiddenCanvases.Length; i++)
        {
            Debug.Log(i + " " + temporarilyHiddenCanvases[i].activeSelf);
            hiddenCanvasesActiveStatus[i] = temporarilyHiddenCanvases[i].activeSelf;
            temporarilyHiddenCanvases[i].SetActive(false);
        }

        Debug.Log(hiddenCanvasesActiveStatus.Length);
    }

    void activateCanvas(){
        if(temporarilyHiddenCanvases == null)
            return;
        Debug.Log(temporarilyHiddenCanvases.Length);
        for(int i = 0; i < temporarilyHiddenCanvases.Length; i++)
        {
            Debug.Log(hiddenCanvasesActiveStatus[i]);
            temporarilyHiddenCanvases[i].SetActive(hiddenCanvasesActiveStatus[i]);
        }

        temporarilyHiddenCanvases = null;
        hiddenCanvasesActiveStatus = null;
    }
}
