using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Capacity : Observer
{
    private GameObject ARCamera;
    private bool visible = false;
    private MeshRenderer[] renderers;

    void Start()
    {
        ARCamera = GameObject.Find("ARCamera");
        //Material Renderers from parent (User's Target GameObject)
        renderers = GetRenderersRecursively(transform.parent.transform.parent);
    }

    void Update(){
        transform.LookAt(ARCamera.transform);
        transform.Rotate(0, 180, 0);
        transform.gameObject.GetComponent<MeshRenderer>().enabled = visible;
    }

    public override void OnNotify(bool isActive, string caller){
        visible = isActive;
        ActivateColorShift(isActive);
    }

    
    private void ActivateColorShift(bool activate)
    {
        foreach (var renderer in renderers)
        {
            Material[] materials = renderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                 materials[i].SetInt("_GlowActive", activate ? 1 : 0);
            }
        }
    }

    MeshRenderer[] GetRenderersRecursively(Transform parent)
    {
        // Initialize a list to store renderers.
        List<MeshRenderer> renderers = new List<MeshRenderer>();

        // Check if the current GameObject has a renderer, and add it to the list if it does.
        MeshRenderer renderer = parent.GetComponent<MeshRenderer>();
        if (renderer != null)
        {
            renderers.Add(renderer);
        }

        // Recursively check the children of the current GameObject.
        foreach (Transform child in parent)
        {
            renderers.AddRange(GetRenderersRecursively(child));
        }

        // Return the combined list of renderers.
        return renderers.ToArray();
    }
}
