using UnityEngine;
using System.Collections;

public class CapturedAudrazeeMediator : MonoBehaviour {

	private Vector3 basePosition;
	
	public float duration = 1f;
	
	public float UpAndDownHeight = 2f;
	
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
		Hashtable ht = 	iTween.Hash("y",basePosition.y + UpAndDownHeight, "time", duration, "onComplete", "MoveDown", "easetype", "easeInOutQuad");
		
		iTween.MoveTo(gameObject,ht);
	}
	
	void MoveDown()
	{
		Hashtable ht = iTween.Hash("y",basePosition.y - UpAndDownHeight, "time", duration, "onComplete", "MoveUp", "easetype", "easeInOutQuad");
		
		iTween.MoveTo(gameObject,ht);
	}
}
