using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
	
	public tk2dSprite itemSprite;
	
	public GameObject particleEffectPrefab;
	
	public virtual void Awake()
	{
		
	}
	
	//
	// logic when taking the item
	//
	public virtual void CollideItem()
	{
		//
		// get the particle effect
		//
		
		if(particleEffectPrefab != null)
		{
 			Spawner.Spawn(particleEffectPrefab, transform.position, Quaternion.identity);	
		}
		
		//
		// destroy the item
		//
		
		Destroy(transform.gameObject);
	}
	
	//
	// executes the action when selecting the item in the bacpack
	//
	public virtual void Select()
	{
		//
		// set in the backpack the current selected ite,
		//
		
		
	}
	
	//
	// cancels the Execute action
	//
	public virtual void Unselect()
	{
	}
	
	//
	// Execute the action of the item
	//
	public virtual void Execute()
	{
		
	}
}
