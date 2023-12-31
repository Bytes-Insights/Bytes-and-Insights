using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class User : Observer
{
    //Shader variables
    private MeshRenderer[] renderers;

    // private Range range;
    private GameObject[] potentialTargets;
    private LineRenderer renderer;

    public bool isTarget;
    public Vuforia.ImageTargetBehaviour imageTarget;
    private bool tracked = false;
    public ImageTracker replacementTracker;

    //Layers
    private bool range_enabled = false;
    private bool connectivity_enabled = false;

    //Connection details
    private bool is_connected = false;
    public float user_load = 1000;
    // 1 to 5 (High to Low)
    public int user_priority = 5;
    private Site site_connection = null;

    //Emojis
    private SpriteRenderer userEmoji;
    public Sprite emoji_happy;
    public Sprite emoji_sad;

    RangeLayerController rangeLayer;
    ConnectivityLayerController connectivityLayer;

    void Start()
    {
        rangeLayer = GameObject.FindGameObjectsWithTag("Button_Ranges")[0].GetComponent<RangeLayerController>();
        connectivityLayer = GameObject.FindGameObjectsWithTag("Button_Connection")[0].GetComponent<ConnectivityLayerController>();
        //Find child GameObject user emoji & deactivate
        userEmoji = transform.Find("UserEmoji").gameObject.GetComponent<SpriteRenderer>();

        //Connection line objects
        potentialTargets = GameObject.FindGameObjectsWithTag("Site_Controller");
        renderer = GetComponent<LineRenderer>();
        renderer.enabled = false;

        //Material Renderers from parent (User's Target GameObject)
        renderers = GetRenderersRecursively(transform.parent);


        if (!imageTarget)
        {
            imageTarget = gameObject.GetComponentInParent<Vuforia.ImageTargetBehaviour>();
        }

        if (imageTarget)
        {
            imageTarget.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    void OnDestroy(){
        if(site_connection != null){
            site_connection.disconnect(transform.gameObject);
        }
    }

    void OnTargetStatusChanged(ObserverBehaviour observerbehavour, TargetStatus status)
    {
        if ((status.Status == Status.TRACKED) && status.StatusInfo == StatusInfo.NORMAL)
        {
            tracked = true;
        }
        else
        {
            this.renderer.enabled = false;
            tracked = false;
            if(site_connection != null){
                site_connection.disconnect(transform.gameObject);
                site_connection = null;
            }
        }
    }

    public bool IsConnected()
    {
        return this.site_connection != null;
    }

    void Update()
    {
        if (!IsTracked())
        {
            Debug.Log("Not tracked.");
            this.renderer.enabled = false;
            return;
        }
        Debug.Log("User tracked.");

        Site eligibleTarget = null;
        Transform eligibleTargetTransform = null;
        double lastDist = double.MaxValue;

        foreach (GameObject potentialTarget in potentialTargets)
        {
            Site site = potentialTarget.GetComponent<Site>();

            if (!site.IsTracked()) continue;
            Debug.Log("Got a tracked site.");

            //float usrMaxRange = range.range;
            float siteMaxRange = site.GetRange().range;
            float requiredRange = siteMaxRange; //Mathf.Min(usrMaxRange, siteMaxRange);

            GameObject referencePoint = FindChildWithTag(potentialTarget.transform, "AntennaReferencePoint");
            Transform targetTransform = referencePoint ? referencePoint.transform : potentialTarget.transform;

            double dist = (targetTransform.position - this.transform.position).magnitude;

            if (dist > requiredRange) continue;

            Debug.Log("Range is okay");

            if (eligibleTarget == null ||
                eligibleTarget.networkVersion < site.networkVersion ||
                (eligibleTarget.networkVersion == site.networkVersion && dist < lastDist))
            {
                Debug.Log("Updating");
                eligibleTarget = site;
                eligibleTargetTransform = targetTransform;
                lastDist = dist;

                
            }
        }

        //If site has changed, we disconnect from previous one
        if((eligibleTarget != site_connection || eligibleTarget == null) && site_connection != null){
            site_connection.disconnect(transform.gameObject);
            setEmoji(false);
            Debug.Log("Disconnection of previous site");
            if(eligibleTarget == null)
                site_connection = eligibleTarget;
        }

        //Try connecting to new site
        if(eligibleTarget !=null){
            Debug.Log("SOME OTHER TEXT TO RECOGNISE IT");
            Debug.Log(range_enabled);
            Debug.Log(connectivity_enabled);
        }
        if (eligibleTarget != null && (rangeLayer.getIsActive() || connectivityLayer.getIsActive()))
        {
            //Connect to new target
            if(eligibleTarget != site_connection){
                eligibleTarget.GetComponent<Site>().connectToSite(transform.gameObject, user_load);
                site_connection = eligibleTarget;
            }

            //Draw connection line
            renderer.enabled = true;
            renderer.SetPosition(0, transform.position);
            renderer.SetPosition(1, eligibleTargetTransform.position);
            
        }
        else
        {
            renderer.enabled = false;
        }

        userEmoji.enabled = connectivity_enabled;
            
        if(eligibleTarget == null)
            setEmoji(false);
        
    }
    GameObject FindChildWithTag(Transform parent, string tag)
    {
        foreach (Transform child in parent)
        {
            if (child.CompareTag(tag))
            {
                return child.gameObject;
            }
        }
        return null;
    }

    public override void OnNotify(bool isActive, string caller){
        if(caller == "RangeLayerController")
            range_enabled = isActive;
        if(caller == "ConnectivityLayerController"){
            connectivity_enabled = isActive;
            ActivateColorShift(isActive);
        }
        if(caller == "Site"){
            is_connected = isActive;
        }
    }

    public void setEmoji(bool isHappy){
        if(isHappy)
            userEmoji.sprite=emoji_happy;
        else
            userEmoji.sprite=emoji_sad;
        UpdateColorShift(isHappy);
    }

    public int getPriority(){
        return user_priority;
    }

    public float getCapacity(){
        return user_load;
    }

    public bool getConnected(){
        return is_connected;
    }

    private void ActivateColorShift(bool activate)
    {
        Debug.Log(transform.parent.gameObject.name);
        foreach (var renderer in renderers)
        {
            Material[] materials = renderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                 materials[i].SetInt("_GlowActive", activate ? 1 : 0);
            }
        }
    }
    private void UpdateColorShift(bool red)
    {
        foreach (var renderer in renderers)
        {
            Material[] materials = renderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                 materials[i].SetInt("_IsConnected", red ? 1 : 0);
            }
        }
    }

    bool IsTracked() {
        if (replacementTracker != null) {
            return replacementTracker.IsTracked();
        }
        return tracked;
    }

    MeshRenderer[] GetRenderersRecursively(Transform parent)
    {
        // Initialize a list to store renderers.
        List<MeshRenderer> renderers = new List<MeshRenderer>();

        // Check if the current GameObject has a renderer, and add it to the list if it does.
        MeshRenderer renderer = parent.GetComponent<MeshRenderer>();
        if (renderer != null)
        {
            renderers.Add(renderer);
        }

        // Recursively check the children of the current GameObject.
        foreach (Transform child in parent)
        {
            renderers.AddRange(GetRenderersRecursively(child));
        }

        // Return the combined list of renderers.
        return renderers.ToArray();
    }
}