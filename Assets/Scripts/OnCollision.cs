using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    public Color colour;
	private double opacity;
	private double factor;
	private bool colliding;
	
	void Start()
	{
		GameObject building = FindChildWithTag("Cube");
		colour=building.GetComponent<MeshRenderer>().material.color;
		opacity=colour.a;
	}
	
    void Update()
    {
        if(colliding==true & factor!=0.3)
		{
				factor-=0.1;
				opacity=opacity*factor;
        }
		else if(colliding==false & factor!=1){
				factor+=0.1;
				opacity=opacity*factor;
			
		}
		
    }
	
	private void OnTriggerEnter(Collider other)
	    {
	        colliding=true;
	    }
		
	private void OnTriggerExit(Collider other)
		    {
		        colliding=false;
		    }
}
