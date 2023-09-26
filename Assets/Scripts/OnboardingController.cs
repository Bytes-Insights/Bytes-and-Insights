using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class OnboardingController : MonoBehaviour
{
    public GameObject canvasStepOne;
    public GameObject canvasStepTwo;
    public UIDocument documentStepOne;
    public UIDocument documentStepTwo;

    private void Start()
    {
        canvasStepOne.SetActive(true);
        canvasStepTwo.SetActive(false);

        VisualElement rootOne = documentStepOne.GetComponent<UIDocument>().rootVisualElement;
        Button nextButtonOne = rootOne.Q<Button>("NextButton");
        nextButtonOne.clicked += ShowStepTwo;
    }

    void ShowStepTwo()
    {
        canvasStepOne.SetActive(false);
        canvasStepTwo.SetActive(true);

        VisualElement rootTwo = documentStepTwo.GetComponent<UIDocument>().rootVisualElement;
        Button nextButtonTwo = rootTwo.Q<Button>("NextButton");
        nextButtonTwo.clicked += StartApp;
    }

    void StartApp()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
