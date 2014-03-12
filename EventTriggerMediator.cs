using UnityEngine;
using System.Collections;

public class EventTriggerMediator : MonoBehaviour {
	
	void OnTriggerEnter(Collider other)
	{
		UnitPlayer player = other.GetComponent<UnitPlayer>();
		
		if(player != null)
		{
			//
			// invoke the history event
			//
			
			Messenger.Broadcast(HistoryEvent.Start, "1");
		}
	}
}
