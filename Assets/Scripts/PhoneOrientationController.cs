using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneOrientationController : MonoBehaviour
{
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
}
