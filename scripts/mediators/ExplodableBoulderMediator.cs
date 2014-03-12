using UnityEngine;
using System.Collections;

public class ExplodableBoulderMediator : MonoBehaviour 
{
	public ExplosionListener explosionListener;
	
	public ExplosionMediator bombMediator;
	
	public GameObject DestructionParticle;
	
	// Use this for initialization
	void Start () 
	{
		explosionListener.OnExplosionHit += OnExplosionHitHandler;
	}
	
	
	void OnExplosionHitHandler( GameObject other, ExplosionVO explosion )
	{
		//
		// disapear the object and spawn a boulder destruction particle
		//
		
		Spawner.Spawn( DestructionParticle, transform.position, Quaternion.identity );
		
		//
		// finally dispatch a explosion using the bomb mediator
		//
		
		bombMediator.ActivateBomb();
		
		//
		// let the bomb mediator destroy the object
		//
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
