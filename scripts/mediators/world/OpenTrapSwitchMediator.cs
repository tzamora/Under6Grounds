using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class OpenTrapSwitchMediator : MonoBehaviour
{
	public tk2dSprite SwitchBaseSprite;
	
	private bool TurnedOn;
	
	// Use this for initialization
	void Start () 
	{
		TurnOff();
	}
	
	void TurnOn()
	{
		//
		// what to do when the switch is enabled
		//
		
		SetState(true);
	}
	
	void TurnOff()
	{
		//
		// what to do when the switch is disabled
		//
		
		SetState(false);
	}

	void SetState(bool state)
	{
		if(state == TurnedOn)
		{
			return;
		}
		
		TurnedOn = state;
		
		SetSwitchColor();
	}
	
	void OnTriggerEnter()
	{
		TurnedOn = true;
		
		SetSwitchColor();
		
		if(InventoryManager.Get.Inventory.Gem)
		{
			CameraFade.StartAlphaFade(Color.white, false, 2f, 0f, () => { Application.LoadLevel(ScenesNamesEnum.Intro); });
		}
	}
	
	void SetSwitchColor()
	{
		if(TurnedOn)
		{
			SwitchBaseSprite.color = Color.yellow;
		}
		else
		{
			SwitchBaseSprite.color = Color.black;
		}
	}
}
