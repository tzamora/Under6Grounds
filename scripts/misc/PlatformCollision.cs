//C#
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
public class PlatformCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			transform.parent.collider.isTrigger = false; 
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			transform.parent.collider.isTrigger = true; 
		}
	}
}