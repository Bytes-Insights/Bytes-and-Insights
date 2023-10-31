using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ConnectivityLayerController : Subject
{
    public bool isActive = false;
    public VirtualButtonInteraction Vbi;

    void Start()
    {
        Vbi.OnExecute += setIsActive;
        setSubjectName("ConnectivityLayerController");
        //Push all sites as observers
        StoreObserversWithTag("User");
        StoreObserversWithTag("Site_CapacityController");
    }

    void setIsActive(string caller){
        if(caller == "VirtualButtonInteractionConnectivity"){
            Debug.Log(caller);
            isActive = !isActive;
            NotifyObserver(isActive);
        }
    }
}
