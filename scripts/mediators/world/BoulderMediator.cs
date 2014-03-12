using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class BoulderMediator : MonoBehaviour {
	
	public ExplosionListener explosionListener;
	
	// Use this for initialization
	void Start ()
	{
		explosionListener.OnExplosionHit += OnExplosionHitHandler;
	}
	
	void OnExplosionHitHandler(GameObject other, ExplosionVO explosion)
	{
		rigidbody.AddExplosionForce(explosion.BombPower, explosion.ExplosionPos, explosion.BombUpwardForce);
	}
}
