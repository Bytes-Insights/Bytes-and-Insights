using System;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    public GameObject building;
    private Color colour;
	private Color oldColor;
	private Color newColor;
	private Material currentMat;
    private float opacity;
    private float factor;
    private bool colliding;

    void Start()
    {
        colliding = false;
        colour = building.GetComponent<MeshRenderer>().material.color;
		currentMat = gameObject.GetComponent<Renderer>().material;
        //Debug.Log("Building identified");
        opacity = colour.a;
    }

    void Update()
    {
        if (colliding)
        {
            factor = 0;
            oldColor = currentMat .color;
        	newColor = new Color(oldColor.r, oldColor.g, oldColor.b, factor);
        	currentMat .SetColor("_Color", newColor);
            //Debug.Log("Decrease opacity");
        }
        else
        {
            factor = 1;
            oldColor = currentMat .color;
        	newColor = new Color(oldColor.r, oldColor.g, oldColor.b, factor);
        	currentMat .SetColor("_Color", newColor);
            //Debug.Log("Increase opacity");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        colliding = true;
        //Debug.Log("Collided");
    }

    private void OnTriggerExit(Collider other)
    {
        colliding = false;
        //Debug.Log("Separated");
    }
}