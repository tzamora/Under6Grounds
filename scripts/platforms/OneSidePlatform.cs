using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[RequireComponent(typeof(Collider))]
public class OneSidePlatform : MonoBehaviour 
{
	public RaycastListener raycastListener;
	
	private bool insidePlatform = false;
	
	void Start () 
	{
		raycastListener.OnRaycastHit += OnRaycastHitHandler;
	}
	
	private void OnRaycastHitHandler(GameObject other)
	{
		//
		// while we are beign shoot by any raycast
		// set the insidePlatform in true to "solidify"
		// the platform
		//
		
		insidePlatform = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(insidePlatform)
		{
			collider.isTrigger = false;
			
			insidePlatform = false;
		}
		else
		{
			collider.isTrigger = true;
		}
	}
}
