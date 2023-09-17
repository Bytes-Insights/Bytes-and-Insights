using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBox_Event_Controller : MonoBehaviour
{

    private GameObject canvas;
    private List<GameObject> carrousels;
    private int carrouselCounter;
    //Dictionary<GameObject, bool> carrousels = new Dictionary<GameObject, bool>();

    // Start is called before the first frame update
    void Start()
    {
        //Initiate counter to 0
        carrouselCounter = 0;

        //Get canvas
        canvas = GameObject.Find("Canvas");

        //Get all textboxes
        carrousels = new List<GameObject>();
        foreach (Transform child in canvas.transform)
        {
            carrousels.Add(child.gameObject);
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        if(carrousels[carrouselCounter].activeInHierarchy){
            Debug.Log(carrouselCounter);
            carrouselCounter++;
        }
    }
}
