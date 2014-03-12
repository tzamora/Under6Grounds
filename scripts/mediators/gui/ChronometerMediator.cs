using UnityEngine;
using System.Collections;

public class ChronometerMediator : MonoBehaviour {
	
	public float ChronometerTime = 30f;
	
	public TextMesh textMesh;
	
	private float elapsedTime = 0f;
	
	private bool enableChronometer = false;
	
	public AudioClip CountDownSong;
	
	// Use this for initialization
	void Start () 
	{
		this.gameObject.Hide();
		
		Messenger.AddListener(ChronometerEvent.StartCountDown, StartCountDownHandler);
	}
	
	void OnDestroy()
	{
		Messenger.RemoveListener(ChronometerEvent.StartCountDown, StartCountDownHandler);
	}
	
	void StartCountDownHandler()
	{
		this.gameObject.Show();
		
		enableChronometer = true;
		
		SoundManager.Get.StopAllClips();
		
		SoundManager.Get.PlayClip( CountDownSong, false );
	}
	
	// Update is called once per frame
	void Update () 
	{
		//
		//display the timer
  		//
		
		if(!enableChronometer)
		{
			return;
		}
		
		//
		// set the text time
		//
		
		int roundedRestSeconds = Mathf.CeilToInt( ChronometerTime - elapsedTime );
    	
		int displaySeconds = roundedRestSeconds % 60;
    	
		int displayMinutes = roundedRestSeconds / 60; 

		textMesh.text = string.Format ("{0:00}:{1:00}", displayMinutes, displaySeconds);
		
		elapsedTime += Time.deltaTime;
		
		//
		// if the time is over then 
		//
		
		if( roundedRestSeconds <= 0 )
		{
			CameraFade.StartAlphaFade( Color.white, false, 3.5f, 1.2f, () => { Application.LoadLevel(ScenesNamesEnum.World1Level1); } );
			
			enableChronometer = false;
		}
	}
}
