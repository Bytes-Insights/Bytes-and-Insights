using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class RangeLayerController : Subject
{
    public bool isActive = false;
    public VirtualButtonInteraction Vbi;

    void Start()
    {
        Vbi.OnExecute += setIsActive;

        setSubjectName("RangeLayerController");

        //Push all sites as observers
        StoreObserversWithTag("Site_Controller");
        StoreObserversWithTag("User");
    }

    void setIsActive(string caller){
        if(caller == "VirtualButtonInteractionRange"){
            Debug.Log(caller);
            isActive = !isActive;
            NotifyObserver(isActive);
        }
    }

    public void makeRangeButtonAvailable(){
        Vbi.setAvailable();
    }

    public bool getIsActive(){
        return isActive;
    }
}
