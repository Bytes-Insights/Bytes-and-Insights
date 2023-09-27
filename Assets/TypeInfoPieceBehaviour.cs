using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeInfoPieceBehaviour : MonoBehaviour
{
    private GameObject ARCamera;
    private NarrativeController NarrativeController;
    private LayerMask infoPieceLayer;
    private InfoPiecesBehaviour infoPiecesBehaviour;
    private InfoPiecesBehaviour.TowerTypeEnumeration selectedType;

    // Start is called before the first frame update
    void Start()
    {
        ARCamera = GameObject.Find("ARCamera");
        NarrativeController = GameObject.Find("NarrativeController").GetComponent<NarrativeController>();
        infoPieceLayer = LayerMask.GetMask("InfoPieces");

        //Get selected type
        infoPiecesBehaviour = transform.parent.GetComponent<InfoPiecesBehaviour>();
        selectedType = infoPiecesBehaviour.selectedType;
        
        //Insert type
        transform.Find("Text").GetComponent<TextMeshPro>().text = selectedType.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for touch or click input
        if (Input.GetMouseButtonDown(0)) // 0 represents the left mouse button (or touch input)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform a raycast to detect the object
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, infoPieceLayer))
            {
                Debug.Log("HEsdsdsdY!");
                // Check if the ray hit the GameObject this script is attached to
                if (hit.collider.gameObject == gameObject)
                {
                    Debug.Log("HEY!");
                    if(selectedType == InfoPiecesBehaviour.TowerTypeEnumeration.Site)
                        NarrativeController.ExplainSites();

                }
            }
        }
    }
}

