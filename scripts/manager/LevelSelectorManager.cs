using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(tk2dUIItem))]
public class LevelSelectorManager : MonoBehaviour 
{	
	// move the code 
	
	/*Move the code to move between the levels inside the level selector indicator
		
	try in some way to dissapear this class ... or analyze a better aproach regarding this class
	
		*/
	private GroundWorld _groundWorldData;
	
	void Awake()
	{
		Messenger.AddListener<Vector2>(InputEvent.Move, MoveInputEventHandler);
		
		//Messenger.AddListener<LevelSelectorMediator>(LevelEvent.LevelSelected, LevelSelectedEventHandler);
	}
	
	void MoveInputEventHandler(Vector2 direction)
	{
		if(direction.x > 0)
		{
			MoveToNextLevel();
		}
		
		if(direction.x < 0)
		{
			//MoveToPreviousLevel();
		}
	}
	
	void MoveToNextLevel()
	{
		//
		// set the current level
		// todo validate when we reach the last level
		//
		
		int nextLevel = _groundWorldData.CurrentLevel.LevelNumber + 1;
		
		_groundWorldData.CurrentLevel = _groundWorldData.Levels.Where(l => l.LevelNumber == nextLevel).FirstOrDefault();
		
		//Messenger.Broadcast( LevelEvent.SelectLevel, _groundWorldData.CurrentLevel );
	}
	
	void LevelSelectedEventHandler(LevelSelectorMediator level)
	{
		//
		// mark the level as the current level
		//
	}
		
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//
		// listen for the arrows
		//
	}
}
