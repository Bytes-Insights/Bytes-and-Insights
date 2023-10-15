using System;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    public GameObject building;
    private Color colour;
    private float opacity;
    private float factor;
    private bool colliding;

    void Start()
    {
        colliding = false;
        colour = building.GetComponent<MeshRenderer>().material.color;
        Debug.Log("Building identified");
        opacity = colour.a;
    }

    void Update()
    {
        if (colliding)
        {
            factor = 0;
            colour.a = (float)(opacity * factor);
            Debug.Log("Decrease opacity");
        }
        else
        {
            factor = 1;
            colour.a = (float)(opacity * factor);
            Debug.Log("Increase opacity");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        colliding = true;
        Debug.Log("Collided");
    }

    private void OnTriggerExit(Collider other)
    {
        colliding = false;
        Debug.Log("Separated");
    }
}