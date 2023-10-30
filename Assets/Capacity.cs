using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Capacity : Observer
{
    private GameObject ARCamera;
    private bool visible = false;

    void Start()
    {
        ARCamera = GameObject.Find("ARCamera");
    }

    void Update(){
        transform.LookAt(ARCamera.transform);
        transform.Rotate(0, 180, 0);
        transform.gameObject.GetComponent<MeshRenderer>().enabled = visible;
    }

    public override void OnNotify(bool isActive, string caller){
        visible = isActive;
    }
}
