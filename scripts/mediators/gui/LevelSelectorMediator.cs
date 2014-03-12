using UnityEngine;
using System.Collections;

public class LevelSelectorMediator : MonoBehaviour 
{
	public Level Level;
	
	private tk2dUIItem levelButton;
	
	void Awake()
	{
		//Messenger.AddListener<LevelSelectorMediator>(LevelEvent.SelectLevel, SelectLevelEventHandler);
	}
	
	// Use this for initialization
	void Start () 
	{
		levelButton = GetComponent<tk2dUIItem>();
		
		levelButton.OnClick += LevelButtonClickHandler;
	}
	
	void SelectLevelEventHandler(LevelSelectorMediator selectedLevel)
	{
		//
		// make all the level selector mediators listen to this event
		// when the event is dispatched check on each one of the levels
		// to see which one is the one to select
		//
		
		if(selectedLevel.Level.LevelNumber == this.Level.LevelNumber)
		{
			SelectLevel ();
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void LevelButtonClickHandler()
	{
		SelectLevel();
	}
	
	void SelectLevel()
	{
		//
		// TODO: make the level the currentLevel
		//
		
		//Messenger.Broadcast(LevelEvent.LevelSelected, this);
	}
}
