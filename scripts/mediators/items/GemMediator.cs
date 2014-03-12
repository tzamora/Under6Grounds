using UnityEngine;
using System.Collections;

public class GemMediator : MonoBehaviour 
{
	public GameObject GemPickUpParticle;
	
	public AudioClip PickUpSound;
	
	public GameObject ChronometerPrefab;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	void OnTriggerEnter()
	{
		InventoryManager.Get.Inventory.Gem = true;
		
		SoundManager.Get.PlayClip(PickUpSound, false);
		
		Spawner.Spawn(GemPickUpParticle, transform.position, Quaternion.identity);
		
		//
		// spawn the chronometer in the center of the screen
		//
		
		SpawnChronometer();
		
		//
		// disapatch the gem taked event
		//
		
		Messenger.Broadcast(LevelEvent.GemTaken);
		
		Destroy(this.gameObject);
	}
	
	void SpawnChronometer()
	{
		Messenger.Broadcast(ChronometerEvent.StartCountDown);
	}
}
