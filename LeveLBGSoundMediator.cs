using UnityEngine;
using System.Collections;

public class LeveLBGSoundMediator : MonoBehaviour {
	
	public AudioClip[] BGSounds;
	
	// Use this for initialization
	void Start () 
	{
		foreach(AudioClip clip in BGSounds)
		{
			SoundManager.Get.PlayClip( clip, true );
		}
	}
}
