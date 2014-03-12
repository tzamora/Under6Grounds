using UnityEngine;
using System.Collections;

public class CurrentLevelIndicatorMediator : MonoBehaviour 
{
	void Awake()
	{
		//Messenger.AddListener<LevelSelectorMediator>( LevelEvent.LevelSelected, LevelSelectedEventHandler );
	}
	
	void LevelSelectedEventHandler(LevelSelectorMediator level)
	{
		//
		// Move to the selected level
		//
		
		transform.position = level.transform.position;
		
		// Hashtable ht = 	iTween.Hash("x",basePosition.y + 5f, "time", duration, "onComplete", "MoveDown", "easetype", "easeInOutQuad");
		
		// iTween.MoveTo(gameObject,ht);
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
