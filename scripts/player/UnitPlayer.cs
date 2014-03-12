using UnityEngine;
using System.Collections;
using System;

public class UnitPlayer : Unit
{
	public Inventory _playerInventory;
	
	public bool enabledUnitPlayer = false;

	private Transform currentRespawner;
	
	public GameObject BombPrefab;
	
	public GameObject ChargingForcePrefab;
	
	public GameObject wallCollisionParticlePrefab;
	
	private GameObject currentChargingForceGO;

	private bool isDead = false;
	
	private bool bombAlive = false;
	
	private int side = 1;
	
	private float holdingChargeTime = 0f;
	
	public float ChargingTime = 2f;
	
	void Awake()
	{
		Messenger.AddListener(PlayerEvent.Revive, Revive);
		
		Messenger.AddListener<Vector2>(InputEvent.Move, MoveEventHandler);
		
		Messenger.AddListener(InputEvent.Jump, JumpEventHandler);
		
		//Messenger.AddListener(InputEvent.PlaceBomb, PlaceBombEventHandler);
		
		Messenger.AddListener<bool>(InputEvent.ToggleForce, ToggleForceEventHandler);
	}
	
	void OnDestroy()
	{
		Messenger.RemoveListener(PlayerEvent.Revive, Revive);
		
		Messenger.RemoveListener<Vector2>(InputEvent.Move, MoveEventHandler);
		
		Messenger.RemoveListener(InputEvent.Jump, JumpEventHandler);
		
		///Messenger.RemoveListener(InputEvent.PlaceBomb, PlaceBombEventHandler);
		
		Messenger.RemoveListener<bool>(InputEvent.ToggleForce, ToggleForceEventHandler);
	}
	
	private void ToggleForceEventHandler(bool enable)
	{
		ToggleForce( enable );
	}
	
	public override void Start ()
	{
		base.Start ();
		
		Messenger.Broadcast(CameraEvent.Focus, transform);
	}
	
	// Update is called once per frame
	public override void Update () 
	{
		if(GameData.Get.CurrentGameState != GameStatesEnum.playing)
		{
			return;
		}
		
		base.Update();
		
		if(!renderer.IsVisibleFrom(Camera.mainCamera))
		{
			transform.renderer.enabled = false;
		}
		else
		{
			transform.renderer.enabled = true;
		}
		
		CheckGround();
	}
	
	void PlaceBombEventHandler()
	{
		PlaceBomb();
	}
	
	void CrouchEventHandler()
	{
		Crouch(true);
	}
	
	void StandUpEventHandler()
	{
		Crouch(false);
	}
	
	void MoveEventHandler(Vector2 direction)
	{
		//
		// here we will make the input increase based on the time
		// we keep pressed forward
		//
		
		this.inputX = direction.x;
		
		//
		// get the direction
		//
		
		if(inputX > 0)
		{
			side = 1;		
		}
		
		if(inputX < 0)
		{
			side = -1;
		}
	}
	
	void JumpEventHandler()
	{
		Jump();
	}
	
	public void OnTriggerEnter(Collider other)
	{
		//
		// when we finish with the collider
		//
		
		if(other.tag == "jumper")
		{
			//
			// make the player do a super jump
			//
			
			SuperJump();
		}
		
		if(other.tag == "item")
		{
			//
			// since we know is a item get the item component
			//
			
			Item item = other.GetComponent<Item>();
			
			item.CollideItem();
			
			Messenger.Broadcast(SoundEvent.PlaySound, "key");
		}
	}
	
	public void Move(Vector3 moveVector)
	{
		//move += moveVector;
		
		//move.Normalize();
	}
	
	public void Jump()
	{
		if(characterController.isGrounded)
		{
			jump = true;
		}
	}
	
	public void SuperJump()
	{
		jump = true;
		
		superJump = true;
	}
	
	public void Revive()
	{
		//
		// search for the latest spawner you have crossed
		//
		if(currentRespawner)
		{
			transform.position = currentRespawner.transform.position;
			
			Messenger.Broadcast(ChronometerEvent.Continue);
			
			Messenger.Broadcast(CameraEvent.Focus, this.transform);
			
			//
			// set again the playerZ to 0
			//
			
			RestoreZ();
			
			Invoke("IsDeadToTrue",2.0f);
		}
	}
	
	public void IsDeadToTrue()
	{
		isDead = false;
	}
	
	void Kill()
	{
		Messenger.Broadcast(CameraEvent.Unfocus);
		
		isDead = true;
				
		Messenger.Broadcast(ChronometerEvent.Stop);
		
		//
		// make the player fall
		//
		
		PushToFall();
	}
	
	/// <summary>
	/// Checks the ground. 
	/// </summary>
	public void CheckGround()
	{
		//
		// this code help us to keep the enemy from
		// falling from the platforms
		// throw a raycast
		// shotting downwards
		//
		
		Vector3 rayPosition = transform.position;
		
		rayPosition.y = rayPosition.y;
		
		float direction = -10f;
		
		//rayPosition.y = transform.position.y + 0.1f;
		
		Vector3 down = transform.TransformDirection(new Vector3(0f,direction,0f));
		
		Debug.DrawRay (rayPosition, down, Color.green);

		RaycastHit hit;  
		
		if (Physics.Raycast(rayPosition, down, out hit, Mathf.Abs( direction )))
		{
			if(hit.transform)
			{
				//
				// [todo] add raycastlistener method in extensions
				//
				
				//
				// get the raycastlistener and invoke the OnRaycastHit event
				//
				
				RaycastListener raycastListener = hit.transform.GetComponent<RaycastListener>();
				
				if(raycastListener != null && raycastListener.OnRaycastHit != null)
				{
					raycastListener.OnRaycastHit(this.gameObject);
				}
			}
		}
	}
	
	public void PlaceBomb()
	{
		//
		// spawn the bomb
		//
		
		Spawner.Spawn( BombPrefab, transform.position, Quaternion.identity );
		
		
		
		/*if(_playerInventory.Bombs > 0)
		{
			_playerInventory.Bombs--;
		}*/
	}
	
	public void ActivateBomb()
	{
		Messenger.Broadcast("activatebombs");
	}
	
	public void ToggleForce(bool enable)
	{
		if(bombAlive) 
		{
			ActivateBomb();
			
			bombAlive = false;
		}
		
		if(enable)
		{
			holdingChargeTime = Time.time;
			
			if(currentChargingForceGO == null)
			{
				currentChargingForceGO = (GameObject) Spawner.Spawn( ChargingForcePrefab, this.transform.position, Quaternion.identity );
				
				currentChargingForceGO.transform.parent = this.transform;
				
				currentChargingForceGO.transform.localPosition = Vector3.zero;
			}
		}
		else
		{
			//
			// when the button os released check the
			// amount of time it pased versus the time 
			// needed to spawn a bomb
			//
			
			if( (Time.time - holdingChargeTime) > ChargingTime)
			{
				Debug.Log("En serio!!!");
				
				if(!bombAlive)
				{
					PlaceBomb();
					
					bombAlive = true;
				}
			}
			
			holdingChargeTime = 0f;
			
			Destroy(currentChargingForceGO);
			
			currentChargingForceGO = null;
		}
	}
 }
