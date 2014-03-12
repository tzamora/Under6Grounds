using UnityEngine;
using System.Collections;

public class RaycastGun : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		
	}
	
	public void Shot(Vector3 origin, Vector3 direction, float distance)
	{
		Debug.DrawRay (origin, direction, Color.green);
		
		RaycastHit hit;
		
		if (Physics.Raycast(origin, direction, out hit, Mathf.Abs( distance )))
		{
			if(hit.transform)
			{	
				//
				// get the raycastlistener and invoke the OnRaycastHit event
				//
				
				RaycastListener raycastListener = hit.transform.GetComponent<RaycastListener>();
				
				if(raycastListener != null)
				{
					raycastListener.OnRaycastHit(this.gameObject);
				}
			}
		}	
	}
}

