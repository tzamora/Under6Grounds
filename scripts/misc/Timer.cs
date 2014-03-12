using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	
	public float duration = 0.0f;
	
	/// <summary>
	/// The elapsed time. The time passed since the timer started
	/// </summary>
	public float elapsedTime = 0f;
	
	/// <summary>
	/// The time each time the timerTicEventHandler method will be called
	/// </summary>
	public float ticTime = 0f;
	
	public int numberOfTics = 0;
	
	public int currentTic;

	private float ticStartTime;
	
	public bool finished = true;
	
	public delegate void TimerFinishEventHandlerDelegate();
	
	public TimerFinishEventHandlerDelegate timerFinishEventHandler;
	
	public delegate void TimerTicEventHandlerDelegate();
	
	public TimerTicEventHandlerDelegate timerTicEventHandler;
	
	// Use this for initialization
	void Start(){
	
	}
	
	// Update is called once per frame
	void Update()
	{
		if(!finished)
		{
			elapsedTime = elapsedTime + Time.deltaTime;
			
			float ticElapsedTime = elapsedTime - ticStartTime;
			
			//
			// handle the tics behavior
			//
			
			if( ticTime > 0 && ticElapsedTime > ticTime)
			{
				bool canTic = false;
				
				//
				// if number of tics is 0 then do tics forever
				// otherwise do it the number of tics
				//
				
				if(numberOfTics == 0)
				{
					canTic = true;
				}
				else
				{
					if(numberOfTics > 0 && currentTic < numberOfTics)
					{
						canTic = true;
					}
				}
				
				if(canTic)
				{
					if(timerTicEventHandler != null)
					{
						timerTicEventHandler();
					}
					
					ticStartTime = elapsedTime;
					
					currentTic++;
					
					if(currentTic >= numberOfTics)
					{
						finished = true;
						
						if(timerFinishEventHandler != null)
						{
							timerFinishEventHandler();
						}
					}
				}
			}
			
			
		}
		
		if(duration > 0)
		{
			if(elapsedTime <= duration)
			{
				finished = true;
				
				if(timerFinishEventHandler != null)
				{
					timerFinishEventHandler();
				}
			}
			else
			{
				finished = false;
			}
		}
	}
	
	public void ResetTimer()
	{	
		currentTic = 0;
		
		elapsedTime = 0;
		
		ticStartTime = 0;
		
		finished = false;
	}
}



