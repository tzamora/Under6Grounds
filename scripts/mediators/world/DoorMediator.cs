using UnityEngine;
using System.Collections;

public class DoorMediator : MonoBehaviour {
	
	public bool OpenAtStart = false;
	
	public SpecialSwitchMediator Switch;
	
	public Transform DoorGroup;
	
	private float timeSinceStart = 0f;
	
	private bool animate = false;
	
	private float OpenY = 0f;
	
	private float ClosedY = 0f;
	
	public float openDuration = 5f;
	
	public float height = 2f;
	
	void Awake()
	{
		Messenger.AddListener(LevelEvent.GemTaken, GemTakenEventHandler);
	}
	
	void GemTakenEventHandler()
	{
		//
		// when the gem is taken close the doors
		//
		
		Close();
	}
	
	// Use this for initialization
	void Start () 
	{
		if(Switch != null)
		{
			Switch.OnSwitchStatusChange += OnSwitchStatusChangeHandler;	
		}
		
		ClosedY = 0;
		
		OpenY = ClosedY + height;
		
		if(OpenAtStart)
		{
			Open();
		}
	}
	
	private void OnSwitchStatusChangeHandler()
	{
		if(Switch.TurnedOn)
		{
			Open();
		}
		else
		{
			Close();
		}
	}
	
	private void Open()
	{
		iTween.MoveTo(DoorGroup.gameObject, iTween.Hash( "y", OpenY, "islocal", true, "time", openDuration));	
	}
	
	private void Close()
	{
		iTween.MoveTo(DoorGroup.gameObject, iTween.Hash( "y", ClosedY, "islocal", true, "time", openDuration));	
	}
}
