using UnityEngine;
using System.Collections;

public class PlayerCollisioner : MonoBehaviour {
	

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
	{
		//Debug.Log( "----->" + GetComponent<CharacterController>().detectCollisions);
		
		GetComponent<CharacterController>().SimpleMove(new Vector3(1f,0f,0f));
	}
	
	void OnTriggerEnter(Collider other)
	{
		Debug.Log("dfdfdfdfdeeee");
		
		Messenger.Broadcast( PlayerEvent.Collide, other );
		
		/*if(other.tag == "Untagged")
		{
			return;
		}
		
		
		if(other.tag == "jumper")
		{
			//
			// make the player do a super jump
			//
			
			player.SuperJump();
		}
		
		if(other.tag == "enemy")
		{
			//
			// make the player do a super jump
			//
			
			//Messenger.Broadcast("chucha");
			
			Enemy enemy = other.GetComponent<Enemy>();
			
			enemy.Kill();
			
			Messenger.Broadcast(SoundEvent.PlaySound, "punch");
		}
		
		if(other.tag == "hole")
		{
			//holeRespawner = other.GetComponent<HoleRespawner>();
			
			//Invoke("RespawnPlayerAfterFall", 0.1f);	
			
			//
			// play fall sound effect
			//
			
			Messenger.Broadcast(SoundEvent.PlaySound, "falling");
			
			//
			// change player image
			//
			
			player.playHoleFall();
			
			//
			// reduce the number of silver keys
			//
			
			GameObject keyCounterText = GameObject.Find("silverKeyCounterText");
			
			TextMesh counterText = keyCounterText.GetComponent<TextMesh>();
		
			if(Backpack.Get.silverKeys > 0)
			{
				Backpack.Get.silverKeys--;
			}
			
			counterText.text = "" + Backpack.Get.silverKeys;
		}
		
		if(other.tag == "item")
		{
			Item item = other.GetComponent<Item>();
			
			//backPack.SaveInBackpack( item );
				
			//
			// do the take item action
			//
			
			item.TakeItem();
		
			ClientObject.Get.Log("Taking item " + Backpack.Get.silverKeys );
			
			//
			// play take item sound 
			//
			
			Messenger.Broadcast(SoundEvent.PlaySound, "takeItem");
		}
		
		if(other.tag == "goal")
		{
			GameManager.Get.FinishGame();
			
			ClientObject.Get.Log("Finishing round");
		}
		
		//
		// !!@#!@#!@#@!#!@#!@# Remove this to the ObstacleCollisioner script
		//
		
		if(other.tag == "obstacle")
		{
			//
			// since we have collided with it already,
			// we have no more use to the collider
			//
			
			other.collider.enabled = false;
			
			player = GetComponent<UnitPlayer>();
		}*/
	}
}
