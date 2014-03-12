using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovablePlatformMediator : MonoBehaviour
{	
	public Vector3 maxPosition;
	
	public Vector3 minPosition;
	
	public TriggerListener EnterPlatformTriggerListener;
	
	public float duration = 3f;
	
	public float StartAt = 0f;
		
	//
	//
	//
	
	private Vector3 tmpMinPos = Vector3.zero;
	
	private Vector3 tmpMaxPos = Vector3.zero;
	
	private List<Transform> itemsOnPlatform;
	
	private Vector3 basePosition;
	
	private float timeSinceStart = 0;
	
	// Use this for initialization
	void Start () 
	{
		basePosition = this.transform.position;
		
		itemsOnPlatform = new List<Transform>();
		
		EnterPlatformTriggerListener.OnEnter += EnterPlatformOnEnter;
		
		EnterPlatformTriggerListener.OnExit += EnterPlatformOnExit;
		
		//
		//
		//
		
		tmpMinPos = basePosition - minPosition;
		
		tmpMaxPos = basePosition + maxPosition;
		
		timeSinceStart = StartAt;
	}

	void Update()
	{
		timeSinceStart += Time.deltaTime;
		
		float t = Mathf.PingPong(timeSinceStart, 1);
		
		
		
		transform.position = Vector3.Lerp(tmpMinPos, tmpMaxPos, t);
	}
	
	void EnterPlatformOnEnter(GameObject other)
	{
		//
		// add any collider that 
		//
		
		itemsOnPlatform.Add(other.transform);
		
		other.transform.parent = this.transform;
	}
	
	void EnterPlatformOnExit(GameObject other)
	{
		itemsOnPlatform.Remove(other.transform);
		
		other.transform.parent = null;
	}
	
	void OnDrawGizmosSelected()
	{
		basePosition = transform.position;
	}
	
	void OnDrawGizmos()
	{
		Gizmos.color = Color.cyan;
        
		Gizmos.DrawLine(transform.position - minPosition, transform.position + maxPosition);
    }
}
