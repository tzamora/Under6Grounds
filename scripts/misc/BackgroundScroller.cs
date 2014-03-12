using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {
	
	public float scrollSpeed = 1;
	
	// Update is called once per frame
	void Update () 
	{ 
		float offset = Mathf.Repeat( Time.time * scrollSpeed, 1);
     
		renderer.sharedMaterial.SetTextureOffset("_MainTex", new Vector2(offset, 0));
	}
}
