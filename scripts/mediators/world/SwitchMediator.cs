using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class SwitchMediator : MonoBehaviour
{
	public bool _turnedOn = false;
	
	public tk2dSprite SwitchButtonSprite;
	
	public tk2dSprite SwitchBaseSprite;
	
	public SwitchTypeEnum _switchType = SwitchTypeEnum.Hold;
	
	public Action OnSwitchStatusChange;
	
	// Use this for initialization
	void Start () 
	{
		SetSwitchBaseColor();
	}
	
	void SetState(bool state)
	{
		if(state == _turnedOn)
		{
			return;
		}
		
		TurnedOn = state;
		
		if(OnSwitchStatusChange != null)
		{
			OnSwitchStatusChange();
		}
		
		SetSwitchColor();
	}
	
	void OnTriggerStay()
	{
		if(SwitchType == SwitchTypeEnum.Hold)
		{
			SetState(true);
		}
	}
	
	void OnTriggerExit()
	{
		if(_switchType != SwitchTypeEnum.Toggle)
		{
			SetState(false);
		}
	}

	void OnTriggerEnter()
	{
		//
		// once the trigger is dispatched set the
		// current state of the switch and update 
		// the ui
		//
		
		if(SwitchType == SwitchTypeEnum.Toggle)
		{
			if(TurnedOn)
			{
				SetState(false);
			}
			else
			{
				SetState(true);
			}
		}
	}
	
	void UpdateUI()
	{
		switch(SwitchType)
		{
			case SwitchTypeEnum.Hold:
				SwitchBaseSprite.color = Color.red;
			break;
			case SwitchTypeEnum.Toggle:
				SwitchBaseSprite.color = Color.green;
			break;
		}
	}
	
	void SetSwitchColor()
	{
		if(TurnedOn)
		{
			SwitchButtonSprite.color = Color.yellow;
		}
		else
		{
			SwitchButtonSprite.color = Color.black;
		}
	}
	
	void SetSwitchBaseColor()
	{
		switch(SwitchType)
		{
			case SwitchTypeEnum.Hold:
				SwitchBaseSprite.color = Color.red;
			break;
			case SwitchTypeEnum.Toggle:
				SwitchBaseSprite.color = Color.green;
			break;
		}
	}
	
	public bool TurnedOn 
	{
		get 
		{
			return this._turnedOn;
		}
		set 
		{	
			if(_turnedOn != value)
			{
				_turnedOn = value;
			}
		}
	}
	
	public SwitchTypeEnum SwitchType 
	{
		get 
		{
			return this._switchType;
		}
		set 
		{
			_switchType = value;
			
			UpdateUI();
		}
	}	
}
