using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    //private
    private Material sphere_material;
    private Color tempcolor;
    
    //public
    public float range;
    public float opacity;
    public Material range_material;

    // Start is called before the first frame update
    void Start(){
        //Create sphere of range given the range, opacity and material selected
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.parent = this.transform;
        sphere.transform.position = this.transform.position;
        //Apparently, localScale scales an object based on the parent object. Can't add the ranges as children because then we lose track of scale units (A 4.0f for an antenna is not the same for its range)
        sphere.transform.localScale = new Vector3(range, range, range);
        sphere.GetComponent<Renderer>().material = range_material;

        /*Opacity*/
        //Need to do all this mess because 'sphere.GetComponent<MeshRenderer>().material.color' seems to return a copy of the material, therefore can't modify it directly
        tempcolor = sphere.GetComponent<MeshRenderer>().material.color;
        tempcolor.a = opacity;
        sphere.GetComponent<Renderer>().material.color = tempcolor;

        /*Naming & Tagging*/
        sphere.tag = "Range";
    }
}
