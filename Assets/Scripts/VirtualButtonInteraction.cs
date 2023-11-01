using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButtonInteraction : MonoBehaviour
{
    public VirtualButtonBehaviour virtualButton;
    public ProgressCircleManager circle;
    public GameObject trackedTarget;
    public GameObject buttonVisual;
    public Color unusedColor;
    public Color usedColor;

    public delegate void ExecuteEventHandler(string caller);
    public event ExecuteEventHandler OnExecute;

    public float delay = 0.3F;
    public float triggerTime = 3F;

    private float runningTimer = 0F;
    private bool pressed = false;
    private bool executed = false;
    private bool barVisible = false;

    void Start()
    {
        virtualButton.RegisterOnButtonPressed(OnButtonPressed);
        virtualButton.RegisterOnButtonReleased(OnButtonReleased);

        UpdateMaterial(unusedColor);
    }

    void UpdateMaterial(Color color)
    {
        if (buttonVisual != null && color != null)
        {
            Material material = buttonVisual.GetComponent<Renderer>().material;
            if (material)
            {
                material.SetColor("_MainColor", color);
            }
        }
    }

    void Update()
    {
        if (!pressed || executed)
        {
            return;
        }

        if (runningTimer >= delay)
        {
            if (!barVisible)
            {
                barVisible = true;
                circle.SetTarget(trackedTarget);
                circle.SetDisplayed(true);

                UpdateMaterial(usedColor);
            }

            circle.SetProgress((runningTimer - delay) / triggerTime);
        }

        if (runningTimer >= triggerTime + delay)
        {
            executed = true;
            circle.Reset();

            if (OnExecute != null)
            {
                OnExecute.Invoke(transform.gameObject.name);
            }

            UpdateMaterial(unusedColor);
        }

        runningTimer += Time.deltaTime;
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        pressed = true;
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Reset();
    }

    private void Reset()
    {
        runningTimer = 0F;
        executed = false;
        pressed = false;
        barVisible = false;
        circle.Reset();
        UpdateMaterial(unusedColor);
    }
}
