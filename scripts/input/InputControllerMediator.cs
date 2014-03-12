using UnityEngine;
using System.Collections;

/// <summary>
/// Input controller mediator.
/// handle the player input
/// </summary>
public class InputControllerMediator : MonoBehaviour 
{	
	public tk2dUIItem leftButton;
	
	public tk2dUIItem rightButton;
	
	public tk2dUIItem stopRunButton;
	
	public tk2dUIItem jumpButton;
	
	float inputX = 0f;
	
	float inputY = 0f;
	
	public bool stopped = false;

	// Use this for initialization
	void Start () 
	{
		/*leftButton.LeftClickDownEventHandler = leftButtonClickDownHandler;
		
		leftButton.LeftClickUpEventHandler = leftButtonClickUpHandler;
		
		rightButton.LeftClickDownEventHandler = rightButtonClickDownHandler;
		
		rightButton.LeftClickUpEventHandler = rightButtonClickUpHandler;
		
		stopRunButton.LeftClickDownEventHandler = stopRunButtonClickHandler;
		
		jumpButton.LeftClickDownEventHandler = jumpButtonClickHandler;*/
	}
	
	// Update is called once per frame
	void Update () 
	{
		ListenInput();
	}
	
	void ListenInput()
	{
		for(int i = 0; i <  Input.touchCount; ++i)
		{	
			Touch touch = Input.GetTouch(i);
			
			RaycastHit hit;
			
			//inputX = 0f;
			
			if(leftButton.collider.Raycast( Camera.mainCamera.ScreenPointToRay( touch.position ), out hit, 1000f ) )
			{
				if(touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
				{
					Debug.Log("moving left");
				
					inputX = -1f;	
				}
				
				if(touch.phase == TouchPhase.Ended)
				{
					Debug.Log("stoping");
					
					inputX = 0f;
				}
			}
			
			if(rightButton.collider.Raycast( Camera.mainCamera.ScreenPointToRay( touch.position ), out hit, 1000f ) )
			{
				if(touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
				{
					Debug.Log("moving right");
					
					inputX = 1f;
				}
				
				if(touch.phase == TouchPhase.Ended)
				{
					Debug.Log("stoping");
					
					inputX = 0f;
				}
			}
			
			if(jumpButton.collider.Raycast( Camera.mainCamera.ScreenPointToRay( touch.position ), out hit, 1000f ) )
			{
				if(touch.phase == TouchPhase.Began)
				{
					Debug.Log("jump button pressed");
		
					Messenger.Broadcast(InputEvent.Jump);
				}
			}
		}
		
		#if UNITY_EDITOR || UNITY_WEBPLAYER
		
		// Debug.Log("This message should never be displayed in a mobile device");
		
		inputX = Input.GetAxisRaw("Horizontal");
		
		inputY = Input.GetAxisRaw("Vertical");
		
		if(Input.GetKeyDown( KeyCode.K ) || Input.GetKeyDown( KeyCode.L ))
		{
			Messenger.Broadcast(InputEvent.Jump);
		}
		
		if(Input.GetKeyDown( KeyCode.O ) || Input.GetKeyDown( KeyCode.P ))
		{
			Messenger.Broadcast(InputEvent.ToggleForce, true);
		}
		
		if(Input.GetKeyUp( KeyCode.O ) || Input.GetKeyUp( KeyCode.P ))
		{
			Messenger.Broadcast(InputEvent.ToggleForce, false);
		}
		
		#endif
		
		Vector2 direction = new Vector2(inputX, 0f);
		
		Messenger.Broadcast(InputEvent.Move, direction);
	}
	
	void leftButtonClickDownHandler ()
	{
		inputX = -1;
		
		Debug.Log("left button pressed");
	}

	void leftButtonClickUpHandler ()
	{
		inputX = 0;
	}
	
	void rightButtonClickDownHandler ()
	{
		inputX = 1;
		
		Debug.Log("right button pressed");
	}
	
	void rightButtonClickUpHandler ()
	{
		inputX = 0;
	}
	
	void stopRunButtonClickHandler ()
	{
	}
	
	void jumpButtonClickHandler ()
	{
		Messenger.Broadcast(InputEvent.Jump);
	}
}
