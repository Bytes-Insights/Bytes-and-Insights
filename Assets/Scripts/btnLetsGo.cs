using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnLetsGo : MonoBehaviour
{

    public GameObject firstTextBox;
    public GameObject secondTextBox;

    public GameObject thirdTextBox;

    public GameObject fourthTextBox;

    List<GameObject> boxes = new List<GameObject>();
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {

        boxes.Add(firstTextBox);
        boxes.Add(secondTextBox);
        boxes.Add(thirdTextBox);
        boxes.Add(fourthTextBox);

        //Debug.Log(boxes.Count);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void letsGoButtonClicked() {

        if (index < boxes.Count) {
        
            GameObject currentBox = boxes[index];

            if (currentBox.activeInHierarchy == true) {

                currentBox.SetActive(false);

                if (index != boxes.Count - 1) {

                    GameObject nextBox = boxes[index + 1];

                    if (nextBox.activeInHierarchy == false) {
                        nextBox.SetActive(true);
                    }

                }

            } else {

                currentBox.SetActive(true);
                
            }

            index++;

        } 

    }
}

