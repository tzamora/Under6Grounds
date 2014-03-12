using UnityEngine;
using System.Collections;

public class GameObjectBounds : MonoBehaviour {
	
	public Bounds bounds;
	
	void Awake()
	{
		//
		// the bounds initialization need to be made in the awake behavior method
		// because the start method happens to late after the instatiation.
		//
		
		bounds.center = transform.position;
		
		EncapsulateAllChildren( transform );
		
	}
	
	//
	// Makes the bounds variable to encapsulta all the children
	// and the children of the children
	//
	void EncapsulateAllChildren( Transform parent )
	{
		if(parent.childCount > 0)
		{
			foreach (Transform child in parent)
			{
				if(child.renderer)
				{
					bounds.Encapsulate(child.gameObject.renderer.bounds);
				}
				
				EncapsulateAllChildren(child);
			}
		}
	}
		
	void AddChildrenToBounds( Transform child ) 
	{
	    foreach ( Transform grandChild in child ) 
		{
	        if( grandChild.renderer ) 
			{
	            bounds.Encapsulate( grandChild.renderer.bounds.min );
	
	            bounds.Encapsulate( grandChild.renderer.bounds.max );
	        }
	
	        AddChildrenToBounds( grandChild );
	    }
	}
	
	 
	
	void OnDrawGizmosSelected() {
	
	    // this function shows the bounding box as a white wire cube in the scene view 
	
	    // when the object containing this bound's code is selected 
	
	    var center = bounds.center; 
	
	    var size = bounds.size; 
	
	    Gizmos.color = Color.white; 
	
	    Gizmos.DrawWireCube( center, size ); 
	
	}
	
	// Update is called once per frame
	void Update () {
		
		//EncapsulateAllChildren( transform );
		
	}
}
