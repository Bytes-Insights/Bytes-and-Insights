using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeLayerController : Subject
{
    public bool isActive = false;

    void Start()
    {
        //Push all sites as observers
        Debug.Log("HEYYYY");
        StoreObserversWithTag("Site");
        

    }

    void setIsActive(bool value){
        isActive = value;
        NotifyObserver(isActive);
    }
}
