using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButtonBehaviour : MonoBehaviour
{
    private Camera arCamera;
    private Transform parent;
    public LayerMask targetLayer;

    private SpriteRenderer spriteRenderer;
    public Sprite questionmark;
    public Sprite exit;
    private bool open;
    private float radius;

    public GameObject information;

    // Start is called before the first frame update
    void Start()
    {
        radius = 0f;
        arCamera = GameObject.Find("ARCamera").GetComponent<Camera>();
        parent = transform.parent;
        spriteRenderer = GetComponent<SpriteRenderer>();
        open = false; 
        spriteRenderer.sprite = questionmark;
    }

    // Update is called once per frame
    void Update()
    {
        // Face camera
            Vector3 relativePosition = arCamera.gameObject.transform.right * radius;

            // Set the position of the child object
            transform.position = parent.position + relativePosition;

            // Ensure the object faces the AR camera
            transform.LookAt(arCamera.gameObject.transform);

            transform.position = new Vector3(transform.position.x, parent.position.y + 2.2f, transform.position.z);
            transform.Rotate(Vector3.up, 180f);

        // If tapped
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the mouse position
            Ray ray = arCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform a raycast to see if it hits this object
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, targetLayer) && hit.collider.gameObject == transform.gameObject)
            {
                //Change sprite depending on open or not
                if(open){
                    spriteRenderer.sprite = questionmark;
                }else{
                    spriteRenderer.sprite = exit;
                }
                open = !open;
                information.SetActive(open);
            }
        }
    }
}
