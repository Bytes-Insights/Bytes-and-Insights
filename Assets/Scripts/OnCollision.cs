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
		colour=building.GetComponent<MeshRenderer>().material.color;
		System.Console.WriteLine("building identified");
		opacity=colour.a;
	}
	
    void Update()
    {
        if(colliding==true & factor!=0.3)
		{
				factor-=0.1;
				opacity=opacity*factor;
				System.Console.WriteLine("decrease opacity");
        }
		else if(colliding==false & factor!=1){
				factor+=0.1;
				opacity=opacity*factor;
			System.Console.WriteLine("increase opacity");
		}
		
    }
	
	private void OnTriggerEnter(Collider other)
	    {
	        colliding=true;
			System.Console.WriteLine("collided");
	    }
		
	private void OnTriggerExit(Collider other)
		    {
		        colliding=false;
				System.Console.WriteLine("separated");
		    }
}
