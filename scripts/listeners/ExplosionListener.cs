using UnityEngine;
using System.Collections;
using System;

public class ExplosionListener : MonoBehaviour {

	/// <summary>
	/// Raises the raycast hit event.
	/// </summary>
	/// <typeparam name='GameObject'>
	/// The caster of the ray being hit here.
	/// </typeparam>
	public Action<GameObject, ExplosionVO> OnExplosionHit;
	
	public void Hit( GameObject other, ExplosionVO explosion ) 
	{
		if(OnExplosionHit != null)
		{
			OnExplosionHit( other, explosion );
		}
	}
}
