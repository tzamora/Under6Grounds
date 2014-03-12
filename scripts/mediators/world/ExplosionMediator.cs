using UnityEngine;
using System.Collections;

public class ExplosionMediator : MonoBehaviour {
	
	public float BombTime = 0.2f;
	
	public float BombPower = 500.0f;
	
	public float BombRadius = 1f;
	
	public float BombUpwardForce = 1f;
	
	public GameObject ExplosionParticle;
	
	public bool ShowGizmo = false;
	
	public bool activateOnSpawn = false;
	
	void ActivateBombEventHandler()
	{
		//
		// make the bomb explode
		//
		
		ActivateBomb();
	}
	
	// Use this for initialization
	void Start () 
	{
		//
		// once the bomb is dispatched,
		// set the timeout of the explosion
		//
		if(activateOnSpawn)
		{
			ActivateBomb();
		}
	}
	
	public void ActivateBomb()
	{
		//
		// cancel any invoke made before
		//
		
		CancelInvoke();
		
		Invoke("Explode", BombTime);
	}
	
	private void Explode()
	{
		Vector3 explosionPos = transform.position;
        
		Collider[] colliders = Physics.OverlapSphere(explosionPos, BombRadius);
        
		foreach (Collider hit in colliders) 
		{
			//
			// get the bomb listener
			//
			
			ExplosionListener explosionListener = hit.gameObject.GetComponent<ExplosionListener>();
			
			if(explosionListener)
			{
				ExplosionVO explosion = new ExplosionVO();
				
				explosion.BombPower = BombPower;
				
				explosion.ExplosionPos = explosionPos;
				
				explosion.BombUpwardForce = BombUpwardForce;
				
				explosionListener.Hit(this.gameObject, explosion);
			}
            
            if (hit.rigidbody)
			{
				hit.rigidbody.AddExplosionForce(BombPower, explosionPos, BombUpwardForce);
			}
        }
		
		//
		// spawn the explosion particle
		//
		
		if(ExplosionParticle)
		{
			Spawner.Spawn(ExplosionParticle, transform.position, Quaternion.identity);
		}
		
		
		
		Destroy(this.transform.gameObject);
	}
	
	void OnDrawGizmosSelected()
	{
		if(ShowGizmo)
		{
			Gizmos.DrawSphere(transform.position, BombRadius);	
		}
    }
}
