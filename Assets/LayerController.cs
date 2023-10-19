using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerController : MonoBehaviour
{
    public string Range_LayerTag;
    public string Connections_LayerTag;

    private bool rangeLayer_isActive;
    private bool connectionLayer_isActive;

    GameObject[] rangeObjects;

    void Start(){
        //Deactivate everything
        rangeLayer_isActive = false;
        connectionLayer_isActive = false;

        rangeObjects = GameObject.FindGameObjectsWithTag(Range_LayerTag);
        Debug.Log("ijdfoidfjiodfj"); 
        Debug.Log(rangeObjects);
        this.activateLayer(this.rangeObjects, this.rangeLayer_isActive);
    }

    private void activateLayer(GameObject[] layerObjects, bool activate){
        Debug.Log("ijdfoidfjiodfj");
        foreach (GameObject layerObject in layerObjects)
        {
            if (layerObject != null) { // Check if the object is not null
                layerObject.SetActive(activate);
            }
        }

    }

    public void activateRangeLayer(){
        this.rangeLayer_isActive = !this.rangeLayer_isActive;
        this.activateLayer(rangeObjects, rangeLayer_isActive);
    }

    public void activateConnectionLayer(){
        this.connectionLayer_isActive = !this.connectionLayer_isActive;
    }

    public bool getConnectionLayerStatus(){
        return this.connectionLayer_isActive;
    }
}
