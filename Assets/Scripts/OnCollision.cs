using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision: MonoBehaviour
{
    public GameObject building;
    private Material currentMat;
    private bool colliding;

    void Start()
    {
        colliding = false;
        currentMat = gameObject.GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (colliding)
        {
            // Decrease opacity when colliding
            float currentOpacity = currentMat.GetFloat("_Opacity");
            currentMat.SetFloat("_Opacity", 0f);
        }
        else
        {
            // Increase opacity when not colliding
            float currentOpacity = currentMat.GetFloat("_Opacity");
            currentMat.SetFloat("_Opacity", 1.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        colliding = true;
    }

    private void OnTriggerExit(Collider other)
    {
        colliding = false;
    }
}
