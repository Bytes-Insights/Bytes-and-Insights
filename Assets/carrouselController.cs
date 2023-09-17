using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carrouselController : MonoBehaviour
{

    private List<GameObject> textBoxes;
    private int index;
    private GameObject canvas;
    private textboxController textboxController;

    // Start is called before the first frame update
    void Start()
    {
        //Intitiate index to 0
        index = 0;

        canvas = GameObject.Find("Canvas");
        textboxController = (textboxController) canvas.GetComponent(typeof(textboxController));
        //Get all textboxes
        textBoxes = new List<GameObject>();
        foreach (Transform child in this.transform)
        {
            textBoxes.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void textButtonClicked() {
        if (index < this.transform.childCount) {
            GameObject currentBox = textBoxes[index];
            if (currentBox.activeInHierarchy == true) {
                currentBox.SetActive(false);
                if (index != textBoxes.Count - 1) {
                    GameObject nextBox = textBoxes[index + 1];
                    if (nextBox.activeInHierarchy == false) {
                        nextBox.SetActive(true);
                    }
                }
            } else {
                currentBox.SetActive(true);
            }
            index++;
        }
        if (index == this.transform.childCount){
            textboxController.increasePosition();
            Destroy(this.transform.gameObject);
        }
    }
}
