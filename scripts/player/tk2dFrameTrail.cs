using UnityEngine;
using System.Collections;

public class tk2dFrameTrail : MonoBehaviour
{
	public tk2dSprite FrameSprite;
	// Use this for initialization
	void Start ()
	{
		FrameSprite = GetComponent<tk2dSprite>();
	}
}

