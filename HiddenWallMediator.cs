using UnityEngine;
using System.Collections;

public class HiddenWallMediator : MonoBehaviour {
	
	public static bool ShowFlag = true;
	
	public int id = 0;
	
	private bool show = true;
	
	private bool visible = true;
	
	private float alphaChange = 1f;
	
	private tk2dSprite currentSprite;
	
	public float FadeDuration = 0.1f;
	
	private float timeSinceStart = 0;
	
	private bool invalidateUI = false;
	
	private bool inside = true;
	
	void Awake()
	{
		Messenger.AddListener<int, bool>("HideWall", HideWallEventHandler);
	}
	
	void OnDestroy()
	{
		//Messenger.RemoveListener<int, bool>("HideWall", HideWallEventHandler);
	}
	
	void Start()
	{
		currentSprite = GetComponent<tk2dSprite>();
	}
	
	void HideWallEventHandler(int id, bool show)
	{
		CancelInvoke();
		
		if(id == this.id)
		{
			//CancelInvoke();
			
			this.show = show;
			
			//timeSinceStart = 0;
			
			invalidateUI = true;
			
			//target.renderer.material.color.a -= Time.deltaTime/fadeDuration;
		}
	}
	
	void Update()
	{
		/*if(ShowFlag)
		{
			currentSprite.color = new Color(1,1,1,1);
		}
		else
		{
			currentSprite.color = new Color(1,1,1,0);
		}*/
		
		if(invalidateUI)
		{
			timeSinceStart += Time.deltaTime;
		
			if(ShowFlag)
			{
				//if(!visible)
				//{
					Debug.Log("hidding");
					
					alphaChange = Mathf.Lerp(0, 1, timeSinceStart);
					
					//currentSprite.color = new Color(1,1,1,alphaChange);
				//}
			}
			else
			{
				//if(visible)
				//{
					Debug.Log("showing");
					
					alphaChange = Mathf.Lerp(1, 0, timeSinceStart);
					
					//currentSprite.color = new Color(1,1,1,alphaChange);
				//}
			}
			
			currentSprite.color = new Color(1,1,1,alphaChange);
			
			if(alphaChange == 1f)
			{
				Debug.Log("finishing");
				
				invalidateUI = false;
				
				timeSinceStart = 0;
				
				visible = show;
			}
		}
	}
	
	/*void OnTriggerEnter()
	{
		ShowFlag = false;
		
		//
		// when we step on this collider
		// tell all the sprites of this 
		// to hide them all
		//
		
		//
		// Dont do this while we are invalidating the ui
		//
		
		//if(!invalidateUI)
		//{
			//HideWall();
		
			//
			// avoid the display of the wall for all those invokes already
			//
			
			//CancelInvoke();
			
			//
			// now set to show the wall in one second
			//
			
			//Invoke("ShowWall", 1f);
		//}
		
		//ShowFlag = true;
	}
	
	void OnTriggerExit()
	{
		//Debug.Log("Exit");
		
		//inside = false;
		
		Invoke("ShowWall", 1f);
		
		
	}*/
	
	void OnTriggerStay(Collider other)
	{
		//
		// do it only if beign hit by the player
		//
		
	 	UnitPlayer player = other.GetComponent<UnitPlayer>();
		
		if(player)
		{
			HideWall();
		
			CancelInvoke();
			
			Invoke("ShowWall", 1f);	
		}
	}
	
	void ShowWall()
	{
		//Messenger.Broadcast( "HideWall", id, true);
		
		ShowFlag = true;
		
		invalidateUI = true;
		
		Debug.Log("show wall");
		
		/*if(!inside)
		{
			Messenger.Broadcast( "HideWall", id, true);
		}*/
	}
	
	void HideWall()
	{
		//if(inside)
		//{
		ShowFlag = false;
		
		invalidateUI = true;
		
		Messenger.Broadcast( "HideWall", id, false );
		
		Debug.Log("hide wall");
		//}
		
	}
}
