using UnityEngine;

public class HologramController : MonoBehaviour
{
    private GameObject[] holograms;

    private void Start()
    {
        int childCount = transform.childCount;
        holograms = new GameObject[childCount];

        for (int i = 0; i < childCount; i++)
        {
            holograms[i] = transform.GetChild(i).gameObject;
            holograms[i].SetActive(false);
        }
    }


    public void ActivateHologram(int index)
    {
        if (index < 0 || index >= holograms.Length)
        {
            Debug.LogWarning("Invalid index provided.");
            return;
        }

        for (int i = 0; i < holograms.Length; i++)
        {
            holograms[i].SetActive(i == index);
        }
    }

    public void HideAllHolograms()
    {
        for (int i = 0; i < holograms.Length; i++)
        {
            holograms[i].SetActive(false);
        }
    }
}
