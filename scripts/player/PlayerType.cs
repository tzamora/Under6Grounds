using UnityEngine;
using System.Collections;

public enum PlayerGenderType
{
	BOY,
	GIRL
}
	
public enum TeamColorType
{
	BLUE,
	ORANGE
}

[System.Serializable]
public class PlayerType
{
	public PlayerGenderType gender;
	
	public TeamColorType teamColor;
	
	public PlayerType(PlayerGenderType genderType, TeamColorType teamColorType )
	{
		gender = genderType;
		
		teamColor = teamColorType;
	}
	
	public string GetPlayerAnimationNamePrefix ()
	{
		string playerPrefix = "";
		
		switch (teamColor) 
		{
			case TeamColorType.BLUE:
			{
				playerPrefix += "blue";
			
				break;
			}
			
			case TeamColorType.ORANGE:
			{
				playerPrefix += "orange";
			
				break;
			}
		}
		
		playerPrefix += "_";
		
		switch (gender) 
		{
			case PlayerGenderType.BOY:
			{
				playerPrefix += "boy";
			
				break;
			}
			
			case PlayerGenderType.GIRL:
			{
				playerPrefix += "girl";
			
				break;
			}
		}
		
		playerPrefix += "_";
		
		return playerPrefix;
	}
	
	public static bool operator ==(PlayerType a, PlayerType b)
	{
		// If both are null, or both are same instance, return true.
	    if (System.Object.ReferenceEquals(a, b))
	    {
	        return true;
	    }

	    // If one is null, but not both, return false.
	    if (((object)a == null) || ((object)b == null))
	    {
	        return false;
	    }
		
		return a.gender == b.gender && a.teamColor == b.teamColor;	
	}
	
	public static bool operator !=(PlayerType a, PlayerType b)
	{
		 return !(a == b);
	}
}
