using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBillboard : MonoBehaviour
{
    private GameObject ARCamera;

    void Start()
    {
        ARCamera = GameObject.Find("ARCamera");
    }

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - ARCamera.transform.position);;
    }
}
