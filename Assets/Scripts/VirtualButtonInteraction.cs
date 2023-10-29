using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButtonInteraction : MonoBehaviour
{
    public VirtualButtonBehaviour virtualButton;
    public ProgressCircleManager circle;
    public GameObject trackedTarget;

    public delegate void ExecuteEventHandler();
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
            }

            circle.SetProgress((runningTimer - delay) / triggerTime);
        }

        if (runningTimer >= triggerTime + delay)
        {
            executed = true;
            circle.Reset();

            if (OnExecute != null)
            {
                OnExecute();
            }
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
        pressed = false;
        executed = false;
        barVisible = false;

        circle.Reset();
    }
}
