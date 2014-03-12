using UnityEngine;
using System.Collections;

public class LightBallParticleMediator : MonoBehaviour {
	
	private Vector3 basePosition;
	
	public float duration = 1f;
	
	public float height = 5f;
	
	// Use this for initialization
	void Start () 
	{
		//
		// move up and down
		//
		
		basePosition = transform.position;
		
		MoveUp();
	}
	
	void MoveUp()  
	{
		Hashtable ht = 	iTween.Hash("y",basePosition.y + height, "time", duration, "onComplete", "MoveDown", "easetype", "easeInOutQuad");
		
		iTween.MoveTo(gameObject,ht);
	}
	
	void MoveDown()
	{
		Hashtable ht = iTween.Hash("y",basePosition.y - height, "time", duration, "onComplete", "MoveUp", "easetype", "easeInOutQuad");
		
		iTween.MoveTo(gameObject,ht);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
