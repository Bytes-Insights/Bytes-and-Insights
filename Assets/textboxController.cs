using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textboxController : MonoBehaviour
{

    private List<GameObject> carrousels;
    private int carrouselCounter;
    private bool[] activatedCarrousels;
    // Start is called before the first frame update
    void Start()
    {
        //Initiate counter to 0
        carrouselCounter = 0;

        //Get all textboxes
        carrousels = new List<GameObject>();
        foreach (Transform child in this.transform)
        {
            carrousels.Add(child.gameObject);
        }

        activatedCarrousels = new bool[carrousels.Count];
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void increasePosition(){
        activatedCarrousels[carrouselCounter] = true;
        carrouselCounter++;
    }

    bool canBeShown(int position){
        bool canBeShown = false;
        if(!activatedCarrousels[position] && activatedCarrousels[position-1]){
            canBeShown = true;
        }

        return canBeShown;
    }

    public void textboxLaptopIntroduction(){
        int position = 1;
        if(canBeShown(position)){
            //If so, show carrousel
            carrousels[position].SetActive(true);
        }
    }

    
    public void textboxSiteIntroduction(){
        int position = 2;

        if(canBeShown(position)){
            //If so, show carrousel
            carrousels[position].SetActive(true);
        }
    }

    public void textboxBeamformingIntroduction(){
        int position = 3;

        if(canBeShown(position)){
            //If so, show carrousel
            carrousels[position].SetActive(true);
        }
    }
}
