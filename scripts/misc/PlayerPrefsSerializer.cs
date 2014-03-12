using UnityEngine;
using Serialization;

public class PlayerPrefsSerializer  
{
    public static void Save (string prefKey, object serializableObject)
    {
		string json = UnitySerializer.JSONSerialize(serializableObject);
		
		PlayerPrefs.SetString ( prefKey, json );
    }

    public static object Load (string prefKey)
    {
		string json = PlayerPrefs.GetString (prefKey);
		
		object data = UnitySerializer.JSONDeserialize<object>(json);
		
        return data;
    }

}
