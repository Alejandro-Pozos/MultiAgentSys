using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Agent : MonoBehaviour
{
    public int unique_id;
    public int x, z;
        

    public Agent()
    {
        unique_id = 0;
        x = 0;
        z = 0;
    }

    public static Agent ConvertFromJson(string jsonData){

        Debug.Log("Deserialized Agent");
        return JsonUtility.FromJson<Agent>(jsonData);
    }
        
}
