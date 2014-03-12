using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Collider))]
public class TriggerListener : MonoBehaviour
{
	/// <summary>
	/// Raises the collision hit event.
	/// </summary>
	/// <typeparam name='GameObject'>
	/// The collider being hit here.
	/// </typeparam>
	public Action<GameObject> OnEnter;
	
	public Action<GameObject> OnExit;
	
	public Action<GameObject> OnStay;
	
	void OnTriggerEnter(Collider other)
	{
		if(OnEnter != null)
		{
			OnEnter( other.gameObject );
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if(OnExit != null)
		{
			OnExit( other.gameObject );
		}
	}
	
	void OnTriggerStay(Collider other)
	{
		if(OnStay != null)
		{
			OnStay( other.gameObject );
		}
	}
}
