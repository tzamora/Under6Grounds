using UnityEngine;
using System.Collections;

public class StarItemUIMediator : MonoBehaviour {
	
	/// <summary>
	/// The type of the star we will print.
	/// </summary>
	public StarType starTypeToDisplay;
	
	TextMesh textMesh;
	
	void Awake()
	{
		Messenger.AddListener( PlayerModelEvent.StarsCountChanged, StarsCountChangeEventHandler );
		
		textMesh = GetComponent<TextMesh>();
	}
	
	// Use this for initialization
	void Start () 
	{
		UpdateText();
	}
	
	void StarsCountChangeEventHandler()
	{
		UpdateText();
	}
	
	void UpdateText()
	{
		switch(starTypeToDisplay)
		{
			case StarType.Easy:
				// textMesh.text = PlayerModel.Get.StarInventory.EasyStars + ""; 
			break;
			
			case StarType.Medium:
				// textMesh.text = PlayerModel.Get.StarInventory.MediumStars + "";
			break;
			
			case StarType.Hard:
				// textMesh.text = PlayerModel.Get.StarInventory.HardStars + "";
			break;
		}
	}
}
