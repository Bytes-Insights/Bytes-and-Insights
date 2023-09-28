using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButtonBehaviour : MonoBehaviour
{
    public float radius;
    private bool isOpen;
    private GameObject ARCamera;
    private LayerMask infoButtonLayer;

    //HUDController
    private GameObject HUDController;

    //InfoPieces
    private GameObject infoPieces;

    //Sprite Variables
    private string unclickedSpritePath = "2D Images/infoButton_unclicked";
    private string clickedSpritePath = "2D Images/infoButton_clicked";
    private Sprite unclickedSprite;
    private Sprite clickedSprite;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        //Initialization of private variables
        isOpen = false;
        ARCamera = GameObject.Find("ARCamera");
        infoButtonLayer = LayerMask.GetMask("InfoButtons");

        //HUD Controller
        HUDController = GameObject.Find("HUDController");

        //InfoPieces 
        infoPieces = transform.parent.Find("InfoPieces").gameObject;

        //Load Sprites & Renderer
        unclickedSprite = Resources.Load<Sprite>(unclickedSpritePath);
        clickedSprite = Resources.Load<Sprite>(clickedSpritePath);
        spriteRenderer = GetComponent<SpriteRenderer>();

        //Set Active on Start
        gameObject.SetActive(true);
    }

    void Update()
    {
        transform.position = transform.parent.position;
        transform.LookAt(ARCamera.transform);
        transform.position = transform.position + transform.forward * radius;

        // Check for touch or click input
        if (Input.GetMouseButtonDown(0)) // 0 represents the left mouse button (or touch input)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform a raycast to detect the object
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, infoButtonLayer))
            {
                // Check if the ray hit the GameObject this script is attached to
                if (hit.collider.gameObject == gameObject)
                {
                    onTouch();
                }
            }
        }
    }

    private void onTouch(){
        if(isOpen)
            spriteRenderer.sprite = unclickedSprite;
        else
            spriteRenderer.sprite = clickedSprite;
        isOpen = !isOpen;
        infoPieces.SetActive(isOpen);
        HUDController.GetComponent<HUDController>().controlHUD(gameObject, isOpen);
    }

    public void close(){
        spriteRenderer.sprite = unclickedSprite;
        isOpen = false;
        infoPieces.SetActive(isOpen);
        HUDController.GetComponent<HUDController>().controlHUD(gameObject, isOpen);
    }
}
