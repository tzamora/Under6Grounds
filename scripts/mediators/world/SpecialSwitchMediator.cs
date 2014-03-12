using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class SpecialSwitchMediator : MonoBehaviour
{
	public bool _turnedOn = false;
	
	public tk2dSprite SwitchButtonSprite;
	
	public tk2dSprite SwitchBaseSprite;
	
	public SwitchTypeEnum _switchType = SwitchTypeEnum.Hold;
	
	public Action OnSwitchTypeChange;
	
	public Action OnSwitchStatusChange;
	
	public List<SpecialSwitchMediator> SwitchesAlterators;
	
	public TextMesh SwitchLabel;
	
	private bool commingFromToogle = false;
	
	private bool commingFromTypeChange = false;
	
	// Use this for initialization
	void Start () 
	{
		//
		// for each swith listen when it changes
		// when any one changes, change the state of this
		//
		
		SwitchesAlterators.ForEach( s => s.OnSwitchTypeChange += OnSwitchTypeAlteratorHandler );
		
		SetSwitchBaseColor();
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
	
	void SwitchSwitches()
	{
		//
		// switch of type when the switch is turned on
		//
		
		switch(SwitchType)
		{
			case SwitchTypeEnum.Hold:
				SwitchType = SwitchTypeEnum.Toggle;
			break;
			case SwitchTypeEnum.Toggle:
				SwitchType = SwitchTypeEnum.Hold;
			break;
		}
	}
	
	void OnSwitchTypeAlteratorHandler()
	{
		switch(SwitchType)
		{
			case SwitchTypeEnum.Hold:
				SwitchType = SwitchTypeEnum.Toggle;
			break;
			case SwitchTypeEnum.Toggle:
				SwitchType = SwitchTypeEnum.Hold;
			break;
		}
		
		if(SwitchType == SwitchTypeEnum.Hold)
		{
			TurnOff();
		}
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
		/*if(commingFromToogle)
		{
			return;
		}*/
		
		/*if(SwitchType == SwitchTypeEnum.Hold)
		{
			TurnOn();
		}*/
		
		if(SwitchType == SwitchTypeEnum.Hold)
		{
			SetState(true);
		}
	}
	
	void OnTriggerExit()
	{
		if(_switchType == SwitchTypeEnum.Toggle)
		{
			if(!_turnedOn)
			{
				commingFromTypeChange = false;
				
				SwitchType = SwitchTypeEnum.Hold;
			}
		}
		else
		{
			if(SwitchType == SwitchTypeEnum.Hold)
			{
				TurnOff();
				
				SwitchType = SwitchTypeEnum.Toggle;
			}	
		}
		
		commingFromToogle = false;
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
				TurnOff();	
				
				commingFromToogle = true;
			}
			else
			{
				TurnOn();	
				
				commingFromToogle = true;
			}
		}
	}
	
	void UpdateUI()
	{
		switch(SwitchType)
		{
			case SwitchTypeEnum.Hold:
				SwitchBaseSprite.color = Color.red;
				SwitchLabel.text = "H";
			break;
			case SwitchTypeEnum.Toggle:
				SwitchBaseSprite.color = Color.green;
				SwitchLabel.text = "T";
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
			if(_switchType != value)
			{
				if(commingFromTypeChange)
				{
					commingFromTypeChange = false;
				}
				else
				{
					if(OnSwitchTypeChange != null)
					{
						commingFromTypeChange = true;
						
						OnSwitchTypeChange();
					}
				}
			}
			
			_switchType = value;
			
			UpdateUI();
		}
	}	
}
