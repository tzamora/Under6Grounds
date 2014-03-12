using UnityEngine;
using System.Collections;

public enum ObstacleType
{
	blue,
	red
}

public class ObstacleMediator : MonoBehaviour {
	
	public ObstacleType ObstacleType;
	
	void Awake()
	{
		//
		// listen when the user eats a food item
		//
		
		Messenger.AddListener<bool>( PlayerEvent.FoodPowerEnabled, FoodPowerEnabledEventHandler );
		
		//Messenger.MarkAsPermanent( PlayerEvent.FoodPowerEnabled );
	}
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	void FoodPowerEnabledEventHandler(bool enabled)
	{
		//
		// when the player has consumed the food power enable
		// this obstacle trigger, else disable
		//
		
		Collider collider = GetComponent<Collider>();
		
		collider.isTrigger = enabled;
	}
	
	void OnDestroy()
	{
		//
		// always remember to dispose events from the messenger when the object is destroyed
		//
		
		if (Messenger.eventTable.ContainsKey(PlayerEvent.FoodPowerEnabled)) 
		{	
			Messenger.RemoveListener<bool>(PlayerEvent.FoodPowerEnabled,FoodPowerEnabledEventHandler);
		}
	}
}
