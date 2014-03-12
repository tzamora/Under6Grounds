using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	
	public GameObject killParticles;
	
	CharacterController characterController;
	
	tk2dSprite sprite;
	
	int side = -1; // the enemies begin walking from right to left
	
	void Start ()
	{
		characterController = GetComponent<CharacterController>();
		
		sprite = GetComponent<tk2dSprite>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( (characterController.collisionFlags & CollisionFlags.Above) != 0 )
		{
			Kill();
		}
		
		Move();	
		
		CheckGround();
	}
	
	public void OnTriggerEnter(Collider other)
	{
		if(other.tag == "invisibleWall" || other.tag == "deadHole")
		{
			ChangeSide();
		}
	}
	
	void Move()
	{
		if( characterController.renderer.IsVisibleFrom(Camera.mainCamera) )
		{
			//
			// move sideways
			//
			
			Vector3 move = new Vector3( side, 0f, 0f);
			
			move *= 1f;

			characterController.SimpleMove(move);
		}
		
		if(characterController.isTouchingWall())
		{
			ChangeSide();
		}
	}
	
	public void ChangeSide()
	{
		side = -side;
			
		sprite.FlipX = !sprite.FlipX;
	}
	
	public void CheckGround()
	{
		//
		// this code help us to keep the enemy from
		// falling from the platforms
		// throw a raycast in front of the enemy
		// shotting downwards
		//
		
		Vector3 rayPosition = transform.position;
		
		rayPosition.x = rayPosition.x + (0.2f * side);
		
		Vector3 down = transform.TransformDirection(Vector3.down);
		
		Debug.DrawRay (rayPosition, down, Color.green);

		RaycastHit hit;
		
        if (Physics.Raycast(rayPosition, down, out hit, 3f))
		{
			if(hit.transform)
			{
				if(hit.transform.tag == "deadHole")
				{
					ChangeSide();
				}
			}
		}
	}
	
	public void Kill()
	{
		//
		// Instantiate the kill particles
		//
		
		Destroy( gameObject );
			
		Spawner.Spawn( killParticles, transform.position, Quaternion.identity );
			
		Messenger.Broadcast(SoundEvent.PlaySound, "plop");
	}
}
