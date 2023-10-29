using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class User : Observer
{
    // private Range range;
    private GameObject[] potentialTargets;
    private LineRenderer renderer;

    public  Vuforia.ImageTargetBehaviour imageTarget;
    private bool tracked = false;

    private bool range_enabled = false;
    private bool connectivity_enabled = false;
    private bool isConnected = false;
    private SpriteRenderer userEmoji;
    public Sprite emoji_happy;
    public Sprite emoji_sad;

    //In miliseconds
    public float time_between_connections = 2000.0f;
    private float timer = 0.0f;
    private float last_connection = 0.0f;

    void Start()
    {
        //Find child GameObject user emoji & deactivate
        userEmoji = transform.Find("UserEmoji").gameObject.GetComponent<SpriteRenderer>();

        //Connection line objects
        potentialTargets = GameObject.FindGameObjectsWithTag("Site_Controller");
        renderer = GetComponent<LineRenderer>();
        renderer.enabled = false;

        //Find image target object
        if (!imageTarget)
        {
            imageTarget = gameObject.GetComponentInParent<Vuforia.ImageTargetBehaviour>();
        }

        if (imageTarget)
        {
            imageTarget.OnTargetStatusChanged += OnTargetStatusChanged;
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
        }
    }

    void Update()
    {
        Debug.Log("HEY");
        //Update timer
        timer += Time.deltaTime;

        if (!tracked)
        {
            this.renderer.enabled = false;
            return;
        }

        Site eligibleTarget = null;
        Transform eligibleTargetTransform = null;
        double lastDist = double.MaxValue;

        foreach (GameObject potentialTarget in potentialTargets)
        {
            Site site = potentialTarget.GetComponent<Site>();

            if (!site.IsTracked()) continue;

            //float usrMaxRange = range.range;
            float siteMaxRange = site.GetRange().range;
            float requiredRange = siteMaxRange; //Mathf.Min(usrMaxRange, siteMaxRange);

            GameObject referencePoint = FindChildWithTag(potentialTarget.transform, "AntennaReferencePoint");
            Transform targetTransform = referencePoint ? referencePoint.transform : potentialTarget.transform;

            double dist = (targetTransform.position - this.transform.position).magnitude;
            if (dist > requiredRange) continue;

            if (eligibleTarget == null ||
                eligibleTarget.networkVersion < site.networkVersion ||
                (eligibleTarget.networkVersion == site.networkVersion && dist < lastDist))
            {
                eligibleTarget = site;
                eligibleTargetTransform = targetTransform;
                lastDist = dist;
            }
        }

        if (eligibleTarget != null && (range_enabled || connectivity_enabled))
        {
            renderer.enabled = true;
            renderer.SetPosition(0, transform.position);
            renderer.SetPosition(1, eligibleTargetTransform.position);
        }
        else
        {
            renderer.enabled = false;
        }

        if(!connectivity_enabled)
            userEmoji.enabled = false;

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
        Debug.Log(caller);
        if(caller == "RangeLayerController")
            range_enabled = isActive;
        if(caller == "ConnectivityLayerController")
            connectivity_enabled = isActive;
            userEmoji.enabled = isActive;
        if(caller == "Site"){
            isConnected = isActive;
            //Store connection timestamps
            if(isActive){
                last_connection = timer;
                userEmoji.sprite = emoji_happy;
            }else{
                userEmoji.sprite = emoji_sad;
            }
        }
    }
}