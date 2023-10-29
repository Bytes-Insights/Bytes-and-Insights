using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class RangeLayerController : Subject
{
    public bool isActive = false;
    public VirtualButtonBehaviour Vb;

    void Start()
    {
           
        setSubjectName("RangeLayerController");

        //Push all sites as observers
        StoreObserversWithTag("Site_Controller");
        StoreObserversWithTag("User");

        //Button Behaviour On Pressed
        Vb.RegisterOnButtonPressed(OnButtonPressed);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb){
        setIsActive(!isActive);
    }

    void setIsActive(bool value){
        isActive = value;
        NotifyObserver(isActive);
    }
}
