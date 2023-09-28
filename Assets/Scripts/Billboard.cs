using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private GameObject ARCamera;

    void Start()
    {
        ARCamera = GameObject.Find("ARCamera");
    }

    void Update()
    {
        transform.LookAt(ARCamera.transform);
    }
}
