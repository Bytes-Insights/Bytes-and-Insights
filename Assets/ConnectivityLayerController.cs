using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ConnectivityLayerController : Subject
{
    public bool isActive = false;
    public VirtualButtonBehaviour Vb;

    void Start()
    {
        setSubjectName("ConnectivityLayerController");
        //Push all sites as observers
        StoreObserversWithTag("User");
        StoreObserversWithTag("Site_CapacityController");

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
