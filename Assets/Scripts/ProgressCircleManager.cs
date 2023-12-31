using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressCircleManager : MonoBehaviour
{
    public Image indicatorImage;
    private GameObject target;

    void Start()
    {
        Reset();
    }

    void Update()
    {
        if (!target)
        {
            return;
        }

        Camera camera = Camera.current ?? Camera.main;
        Vector3 worldPosition = target.transform.position;
        Vector3 screenPosition = camera.WorldToScreenPoint(worldPosition);
        screenPosition.z = 0f;

        indicatorImage.transform.position = screenPosition;
    }

    public void Reset()
    {
        SetDisplayed(false);
        SetProgress(0F);
        SetTarget(null);
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }

    public void SetDisplayed(bool displayed)
    {
        this.indicatorImage.enabled = displayed;
    }

    public void SetProgress(float progress)
    {
        progress = Mathf.Clamp(progress, 0, 1);
        this.indicatorImage.fillAmount = progress;
    }
}
