using UnityEngine;
using System.Collections;

public class MessageViewMediator : MonoBehaviour 
{
	public tk2dUIItem view;
	
	public tk2dSprite CharacterSprite;
	
	public TextMesh messageText;
	
	private int currentMessagePos = 0;
	
	private ConversationVO currentConversation;
	
	private bool MessageViewEnabled = false;
	
	void Awake()
	{
		Messenger.AddListener<ConversationVO>(HistoryEvent.StartConversation, StartConversationEventHandler);
		
		//
		// use the jump button to advance to the next text
		//
		
		Messenger.AddListener(InputEvent.Jump, NextMessageButtonClickHandler);
		
		this.gameObject.Hide();
		
		MessageViewEnabled = false;
	}
	

	void NextMessageButtonClickHandler()
	{
		ShowNextMessage();
	}
	
	void ShowNextMessage()
	{
		//
		// advance one message forward
		//
		
		if(!MessageViewEnabled)
		{
			return;
		}
		
		if(currentMessagePos == currentConversation.Messages.Count)
		{
			//
			// hide the view and finish the conversation
			//
			
			EndConversation();
		}
		else
		{
			ShowMessage(currentConversation.Messages[currentMessagePos]);
			
			currentMessagePos++;
		}	
	}
	
	void StartConversationEventHandler(ConversationVO conversation)
	{
		//
		// load the first message
		//
		
		currentConversation = conversation;
		
		currentMessagePos = 0;
		
		MessageViewEnabled = true;
		
		ShowNextMessage();
		
		this.gameObject.Show();
	}
	
	void EndConversation()
	{
		Messenger.Broadcast( HistoryEvent.EndConversation );
		
		MessageViewEnabled = false;
		
		this.gameObject.Hide();
	}
	
	void ShowMessage(MessageVO message)
	{
		CharacterSprite.SetSprite(message.CharacterSprite);
		
		messageText.text = message.Message;
	}
}
