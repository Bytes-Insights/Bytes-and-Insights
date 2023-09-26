using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ExplanationController : MonoBehaviour
{
    public GameObject explanationCanvas;
    public UIDocument explanationDocument;

    void Start()
    {
        explanationCanvas.SetActive(false);
    }

    public void ShowExplanation(string conceptTitle, string description)
    {
        explanationCanvas.SetActive(true);
        VisualElement root = explanationDocument.GetComponent<UIDocument>().rootVisualElement;

        Button exitButton = root.Q<Button>("ExitButton");
        exitButton.clicked += Hide;

        Label title = root.Q<Label>("ConceptTitle");
        title.text = conceptTitle;

        Label explanation = root.Q<Label>("Explanation");
        explanation.text = description;
    }

    public void Hide()
    {
        explanationCanvas.SetActive(false);
    }
}
