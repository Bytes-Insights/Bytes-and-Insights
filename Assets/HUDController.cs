using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    private string siteTargetTag = "SiteTarget";
    private string infoButtonTag = "InfoButton";
    
    private GameObject[] siteTargets;
    private GameObject[] infoButtons;

    //HUD Objects
    private GameObject HUDObjects;
    private Camera ARCamera;
    private Camera HUDCamera;

    //Layers
    private LayerMask defaultLayer;
    private LayerMask HUDLayer;

    void Start()
    {
        //Get Layers
        defaultLayer = LayerMask.NameToLayer("Default");
        HUDLayer = LayerMask.NameToLayer("HUDVisibleLayer");
        Debug.Log(HUDLayer);
        //Get all sites
        siteTargets = GameObject.FindGameObjectsWithTag(siteTargetTag);

        //Get all infoButtons
        infoButtons = GameObject.FindGameObjectsWithTag(infoButtonTag);

        //Find HUD Objects
        HUDObjects = GameObject.Find("ARCamera").transform.Find("HUDObjects").gameObject;
        ARCamera = GameObject.Find("ARCamera").GetComponent<Camera>();
        HUDCamera = HUDObjects.transform.Find("HUDCamera").gameObject.GetComponent<Camera>();

        foreach (GameObject siteTarget in siteTargets)
        {
            // Do something with each siteTarget GameObject
            Debug.Log("Found a GameObject with tag: " + siteTarget.name);
        }
    }

    
    void Update()
    {
        
    }

    private void changeSiteLayer(LayerMask layer, GameObject parent){

        // Iterate through all the children of the parent object and place them all in the new layer except infoButton
        foreach (Transform childTransform in parent.transform)
        {
            if (!childTransform.gameObject.CompareTag("InfoButton") && !childTransform.gameObject.CompareTag("InfoPieces"))
            {
                // Change the layer of the child object
                childTransform.gameObject.layer = layer;
                changeSiteLayer(layer, childTransform.gameObject);
            }
        }
    }

    //Change visibility of info buttons depending on visible : boolean
    private void changeInfoButtonVisibility(bool visible){
        foreach (GameObject infoButton in infoButtons)
        {
            infoButton.SetActive(visible);
        }
    }
    
    public void controlHUD(GameObject infoButton, bool willOpen){
        //Change all infoButtons visibility
        this.changeInfoButtonVisibility(!willOpen);
        
        if(willOpen){
            //Except the clicked button
            infoButton.SetActive(true);

            //Change HUDCamera FOV to parent camera
            HUDCamera.fieldOfView = ARCamera.fieldOfView;

            //Place site in Visible Layer
            this.changeSiteLayer(HUDLayer, infoButton.transform.parent.gameObject);
        }else{
            //Return everything to Default layer
            this.changeSiteLayer(defaultLayer, infoButton.transform.parent.gameObject);
        }
            

        //Change HUD camera and layer active prop.
        HUDObjects.SetActive(willOpen);
    }


}
