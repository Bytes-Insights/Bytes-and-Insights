using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnLetsGo : MonoBehaviour
{

    public GameObject firstTextBox;
    public GameObject secondTextBox;

    List<GameObject> boxes = new List<GameObject>();
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {

        boxes.Add(firstTextBox);
        boxes.Add(secondTextBox);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void letsGoButtonClicked() {

        if (index < boxes.Count) {
        
            GameObject currentBox = boxes[index];
            GameObject nextBox = boxes[index+1];

            index++;

            if (currentBox.activeInHierarchy == true) {

                currentBox.SetActive(false);

                if (nextBox.activeInHierarchy == false) {
                    nextBox.SetActive(true);
                }

            } else {
                currentBox.SetActive(true);
            }

        }

    }
}

