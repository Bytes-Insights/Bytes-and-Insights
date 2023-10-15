using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
	public GameObject building;
	private Color colour;
	private double opacity;
	private double factor;
	private bool colliding;
	
	void Start()
	{
		colliding=false;
		colour=building.GetComponent<MeshRenderer>().material.color;
		Debug.Log("building identified");
		opacity=colour.a;
	}
	
    void Update()
    {
        if(colliding==true)
		{
				factor=0;
				colour.a=opacity*factor;
				Debug.Log("decrease opacity");
        }
		else if(colliding==false){
				factor=1;
				colour.a= Convert.ToSingle(opacity*factor);
			Debug.Log("increase opacity");
		}
		
    }
	
	private void OnTriggerEnter(Collider other)
	    {
	        colliding=true;
			Debug.Log("collided");
	    }
		
	private void OnTriggerExit(Collider other)
		    {
		        colliding=false;
				Debug.Log("separated");
		    }
}
