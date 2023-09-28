using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ExplanationController : MonoBehaviour
{
    public GameObject explanationCanvas;
    public UIDocument explanationDocument;
    public HologramController hologramController;

    public delegate void ClosedEventHandler(string closed);
    public event ClosedEventHandler OnClosed;

    private string currentConcept;
    private int currentHologram = -1;

    void Start()
    {
        explanationCanvas.SetActive(false);
    }

    public void ShowExplanation(string conceptTitle, string description)
    {
        ShowExplanation(conceptTitle, description, -1);
    }

    public void ShowExplanation(string conceptTitle, string description, int hologramId)
    {
        explanationCanvas.SetActive(true);

        currentConcept = conceptTitle;
        currentHologram = hologramId;

        VisualElement root = explanationDocument.GetComponent<UIDocument>().rootVisualElement;

        Button exitButton = root.Q<Button>("ExitButton");
        exitButton.clicked += Hide;

        Label title = root.Q<Label>("ConceptTitle");
        title.text = conceptTitle;

        Label explanation = root.Q<Label>("Explanation");
        explanation.text = description;

        if (hologramId != -1) {
            Button hologramButton = root.Q<Button>("ShowHologramButton");
            hologramButton.visible = true;
            hologramButton.clicked += ShowHologram;
        }
    }

    public void Hide()
    {
        explanationCanvas.SetActive(false);

        string closedConcept = currentConcept;
        currentConcept = null;
        currentHologram = -1;
        
        if (OnClosed != null)
        {
            OnClosed(closedConcept);
        }
    }

    public void ShowHologram()
    {
        if (hologramController.isHologramActive())
        {
            hologramController.HideAllHolograms();
        } else
        {
            hologramController.ActivateHologram(currentHologram);
        }
    }
}
