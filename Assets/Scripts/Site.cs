using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Site : MonoBehaviour
{
    public int networkVersion = 5;
    private Range range;

    void Start()
    {
        range = GetComponent<Range>();

        if (this.networkVersion == 4)
        {
            this.GetComponent<MeshRenderer>().material.color = new Color(0.5566038F, 0.5566038F, 0, 1);
        }
    }

    public Range GetRange()
    {
        return range;
    }
}