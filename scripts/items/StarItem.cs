using UnityEngine;
using System.Collections;

public enum StarType
{
	Easy,
	Medium,
	Hard
}

public class StarItem : Item 
{
	public StarType startType;
	
	public void OnTriggerEnter(Collider other)
	{
		//
		// check if we are being hit by the player
		//
		
		UnitPlayer player = other.transform.GetComponent<UnitPlayer>();
		
		if(player == null)
		{
			return;
		}
		
		Messenger.Broadcast(PlayerModelEvent.AddOneStar, startType);
		
		CollideItem();
	}
	
	public override void CollideItem ()
	{
		//
		// when we take a key item we play the takeitem sound and increase the silver key counter by 1
		//
		
		base.CollideItem();
	}
}
