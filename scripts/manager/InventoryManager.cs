using UnityEngine;
using System.Collections;

public class InventoryManager : MonoSingleton<InventoryManager>
{
	private Inventory _inventory;
	
	public  Inventory Inventory 
	{
		get 
		{
			if(_inventory == null)
			{
				_inventory = new Inventory();
			}
			
			return this._inventory;
		}
		set 
		{
			_inventory = value;
		}
	}
}
