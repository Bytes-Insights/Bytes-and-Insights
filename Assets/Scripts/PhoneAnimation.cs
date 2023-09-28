using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PhoneAnimation : MonoBehaviour
{
    int animationDuration = 1200; //ms
    float runningTime = 0.0f;
    int flipped = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        VisualElement phone = root.Q<VisualElement>("Phone");

        runningTime += Time.deltaTime;
        
        if( runningTime  * 1000 > animationDuration ){
            Debug.Log("Triggered");
            runningTime = 0.0f;
            phone.style.rotate = new Rotate(90f * flipped);
            flipped = (flipped + 1) % 2;
        }
    }
}
