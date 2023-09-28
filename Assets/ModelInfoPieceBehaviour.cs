using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModelInfoPieceBehaviour : MonoBehaviour
{
    private GameObject ARCamera;
    private NarrativeController NarrativeController;
    private LayerMask infoPieceLayer;
    private InfoPiecesBehaviour infoPiecesBehaviour;
    private InfoPiecesBehaviour.SiteModel selectedSite;

    // Start is called before the first frame update
    void Start()
    {
        ARCamera = GameObject.Find("ARCamera");
        NarrativeController = GameObject.Find("NarrativeController").GetComponent<NarrativeController>();
        infoPieceLayer = LayerMask.GetMask("InfoPieces");
        
        //Get selected network
        infoPiecesBehaviour = transform.parent.GetComponent<InfoPiecesBehaviour>();
        selectedSite = infoPiecesBehaviour.selectedSite;
        //Insert type
        transform.Find("Text").GetComponent<TextMeshPro>().text = selectedSite.ToString().Replace("_", "");
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
                
                // Check if the ray hit the GameObject this script is attached to
                if (hit.collider.gameObject == gameObject)
                {
                    
                    if(selectedSite == InfoPiecesBehaviour.SiteModel.AIR_6488)
                        NarrativeController.ExplainAIR6488();
                    else if(selectedSite == InfoPiecesBehaviour.SiteModel.Radio_4415)
                        NarrativeController.ExplainRadio4415();

                }
            }
        }
    }
}
