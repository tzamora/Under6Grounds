using UnityEngine;
using System.Collections;

public class TestClass : MonoBehaviour {
	
	public SpecialSwitchMediator Switch;
	
	private float timeSinceStart = 0f;
	
	private bool animate = false;
	
	private float OpenY = 0f;
	
	private float ClosedY = 0f;
	
	public float openDuration = 5f;
	
	public float height = 2f;
	
	// Use this for initialization
	void Start () 
	{
		//Switch.OnSwitchStateChange += OnSwitchChangeHandler;
		
		ClosedY = transform.position.y;
		
		OpenY = ClosedY + height;
	}
	
	private void OnSwitchChangeHandler()
	{
		if(Switch.TurnedOn)
		{
			iTween.MoveTo(this.transform.gameObject, iTween.Hash( "y", OpenY, "islocal", true, "time", openDuration));	
		}
		else
		{
			iTween.MoveTo(this.transform.gameObject, iTween.Hash( "y", ClosedY, "islocal", true, "time", openDuration));	
		}
	}
}
