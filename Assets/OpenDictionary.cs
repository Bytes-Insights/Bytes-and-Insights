using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDictionary : MonoBehaviour
{
    private Camera arCamera;
    public LayerMask targetLayer;
    public GameObject dictionaryText;
    public GameObject dictionary;

    // Start is called before the first frame update
    void Start()
    {
        arCamera = GameObject.Find("ARCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = arCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, targetLayer) && hit.collider.gameObject == transform.gameObject)
        {
            dictionary.SetActive(true);
            dictionaryText.SetActive(true);
        }
    }
}
