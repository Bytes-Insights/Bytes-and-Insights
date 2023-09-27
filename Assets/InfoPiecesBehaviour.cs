using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPiecesBehaviour : MonoBehaviour
{
    //Private Objects
    private GameObject ARCamera;

    //Enumerations
    public enum NetworkGeneration
    {
        _4G,
        _5G
    }

    public enum TowerTypeEnumeration
    {
        Site,
    }
    
    //Public attr selection
    public NetworkGeneration selectedNetwork;
    public TowerTypeEnumeration selectedType;

    void Start()
    {
        ARCamera = GameObject.Find("ARCamera");
        placeInformation();
    }

    void Update()
    {
        pointTowardsCamera();
    }

    private void placeInformation(){

    }

    private void pointTowardsCamera(){
        // Look at camera
        Vector3 lookDirection = ARCamera.transform.position - transform.position;
        // Make up vector coincide to camera (to make text readable)
        transform.rotation = Quaternion.LookRotation(lookDirection, ARCamera.transform.up);
    }
}
