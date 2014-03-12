using UnityEngine;
using System.Collections;

public class CombateBlink : MonoBehaviour {
	
	float timer = 0;
	
	bool onoff = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void blink()
	{
    	if (Time.time > timer)
		{
			timer = Time.time + 0.4f;
            
			onoff = !onoff;
            
			renderer.enabled = onoff;
		}
	}
}
