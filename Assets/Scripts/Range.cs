using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : Observer
{

    //external
    private bool layer_isActive;

    //private
    private Color tempcolor;
    private GameObject sphere;

    //public
    public float range;
    public float opacity;
    public Material range_material;

    // Start is called before the first frame update
    void Start()
    {
        layer_isActive = false;

        Transform target_transform = transform.parent.transform.parent;

        //Create sphere of range given the range, opacity and material selected
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.parent = target_transform;
        sphere.transform.position = target_transform.position;
        //Apparently, localScale scales an object based on the parent object. Can't add the ranges as children because then we lose track of scale units (A 4.0f for an antenna is not the same for its range)
        sphere.transform.localScale = new Vector3(range * 2, range * 2, range * 2);
        sphere.GetComponent<Renderer>().material = range_material;

        /*Opacity*/
        //Need to do all this mess because 'sphere.GetComponent<MeshRenderer>().material.color' seems to return a copy of the material, therefore can't modify it directly
        tempcolor = sphere.GetComponent<MeshRenderer>().material.color;
        tempcolor.a = opacity;
        sphere.GetComponent<Renderer>().material.color = tempcolor;

        /*Naming & Tagging*/
        sphere.tag = "Layer_Ranges";
        sphere.SetActive(layer_isActive);
    }

    public override void OnNotify(bool isActive){
        layer_isActive = isActive;
        sphere.SetActive(layer_isActive);
    }
}