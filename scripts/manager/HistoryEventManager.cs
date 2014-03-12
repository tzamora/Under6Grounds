using UnityEngine;
using System.Collections;

public class HistoryEventManager : MonoSingleton<HistoryEventManager>
{
	// Use this for initialization
	void Awake () 
	{
		Messenger.AddListener<string>(HistoryEvent.Start,StartHistoryEventHandler);
		
		Messenger.AddListener(HistoryEvent.EndConversation,EndConversationEventHandler);
		
		Messenger.AddListener(LevelEvent.GemTaken,GemTakedEventHandler);
	}
	
	void GemTakedEventHandler()
	{
		GameData.Get.CurrentGameState = GameStatesEnum.paused;
		
		ConversationVO conversation = GameData.Get.GameConversationData.GetConversation( "2" );
	
		Messenger.Broadcast(HistoryEvent.StartConversation, conversation);
	}
	
	void EndConversationEventHandler()
	{
		//
		// return the playing state
		//
		
		GameData.Get.CurrentGameState = GameStatesEnum.playing;
	}
	
	void StartHistoryEventHandler(string conversationID)
	{
		// [TODO] extract this code and place the diferent history events in components
		
		//
		// first stop the control from the user
		//
		
		GameData.Get.CurrentGameState = GameStatesEnum.paused;
		
		//
		// load and start the conversation
		//
		
		ConversationVO conversation = GameData.Get.GameConversationData.GetConversation( conversationID );
	
		//
		// Start conversation
		//
		
		Messenger.Broadcast(HistoryEvent.StartConversation, conversation);
	}
}
