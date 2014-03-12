using UnityEngine;
using System.Collections;

/// <summary>
/// Scene load. Initial scene preparation
/// </summary>
public class GameManager : MonoSingleton<GameManager> {
	
	private GameStatesEnum currentState = GameStatesEnum.unstarted;

	Timer timer;
	
	private float startTime = 0f;
	
	TextMesh startCountText;
	
	tk2dSprite countDownNumberSprite;
	
	tk2dSprite countDownLabelSprite;
	
	tk2dSprite combateLogoSprite;
	
	private int countDownNumber = 2;
	
	public bool MainTitleDisplayed = false;
	
	public bool hideLogo = false;
	
	void Awake()
	{
		currentState = GameStatesEnum.unstarted;
		
		Messenger.AddListener( GameEvent.Pause, PauseEventHandler );
		
		Messenger.AddListener( GameEvent.Continue, ContinueEventHandler );
		
		Messenger.AddListener( GameEvent.Finish, FinishEventHandler );
	}
	
	// Use this for initialization
	void Start () 
	{	
		//
		// each time the level is loaded restart data
		//

		// PlayerModel.Get.ResetLevelData();
		
		//
		// set the timer event to begin the game
		//
		timer = GetComponent<Timer>();
		
		//
		// tic each 0.8 seconds 4 times
		//
		
		if(timer != null)
		{
			timer.ticTime = 0.8f;
			
			timer.numberOfTics = 4;
			
			timer.timerTicEventHandler = TimerTicEventHandler;
			
			timer.timerFinishEventHandler = TimerFinishEventHandler;
		}
		
		Invoke("StartGame", 4f);
		
		//
		// play background 
		//
		
		Messenger.Broadcast(SoundEvent.PlayBackgroundSound, "background");
	}
	
	// Update is called once per frame
	void Update () 
	{
		//
		// check if the timer reaches to zero
		//
		
		if(currentState == GameStatesEnum.playing)
		{
			currentState = GameStatesEnum.finished;
		}
		
		if(hideLogo)
		{
			startTime += Time.deltaTime;
			
			float alphaValue = Mathf.Lerp(1f, 0f, startTime);
		
			combateLogoSprite.color = new Color(1f, 1f, 1f, alphaValue); 
		}
	}
	
	void PauseEventHandler()
	{
		currentState = GameStatesEnum.paused;
		
		Time.timeScale = 0;
	}
	
	void ContinueEventHandler()
	{
		currentState = GameStatesEnum.playing;
		
		Time.timeScale = 1;
	}
	
	void FinishEventHandler()
	{
		currentState = GameStatesEnum.finished;
	}
	
	void StartGame()
	{
		//
		// start the timer
		//
		
		if(timer != null)
		{
			timer.ResetTimer();
		}
		
		Time.timeScale = 1f;
		
		//
		// clean the values in the PlayerModel for this scene
		//
		
		//PlayerModel.Get.ResetLevelData();
		
		//
		// for this version make de game begin inmediately
		//
		
		BeginGame();
	}
	
	void TimerTicEventHandler()
	{
		if(countDownNumber == 0)
		{
			//countDownLabelSprite.transform.renderer.enabled = false;
			
			//countDownNumberSprite.transform.renderer.enabled = false;
			
			//combateLogoSprite.transform.renderer.enabled = true;
			
			//Invoke("HideCombateLogo", 1f);
		}
		else
		{
			//countDownNumberSprite.SetSprite("Counter" + countDownNumber);
			
			countDownNumber -= 1;
		}
	}
	
	void HideCombateLogo()
	{
		//
		// lerp the logo alpha to zero
		//
		
		hideLogo = true;
		
		BeginGame();
	}
	
	void TimerFinishEventHandler()
	{
		//
		// begin the game
		//
		
		currentState = GameStatesEnum.playing;
		
		//
		// start the chronometer
		//
		
		Messenger.Broadcast(ChronometerEvent.Play);
	}
	
	void BeginGame()
	{
		//
		// begin the game
		//
		
		currentState = GameStatesEnum.playing;
		
		//
		// start the chronometer
		//
		
		Messenger.Broadcast(ChronometerEvent.Play);
	}
	
	public GameStatesEnum CurrentState
	{
		get
		{
			return this.currentState;
		}
	}	
}
