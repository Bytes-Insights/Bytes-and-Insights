using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ConnectivityLayerController : Subject
{
    public bool isActive = false;
    public VirtualButtonBehaviour Vb;
    public string subject_name = "ConnectivityLayerController";

    void Start()
    {
        //Push all sites as observers
        StoreObserversWithTag("Site_ConnectivityController");

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
