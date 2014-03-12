using UnityEngine;
using System.Collections;

public class StartButtonMediator : MonoBehaviour {
	
	public tk2dUIItem startButton;
	
	// Use this for initialization
	void Start () 
	{
		startButton.OnClick += StartButtonClickHandler;
	}
	
	void StartButtonClickHandler()
	{
		CameraFade.StartAlphaFade( Color.white, false, 3.5f, 1.2f, () => { Application.LoadLevel(ScenesNamesEnum.World1Level1); } );
	}
}
