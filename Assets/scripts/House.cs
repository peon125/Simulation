using UnityEngine;

public class House : Building 
{
    public Vector3 Position
    {
        get
        {
            return transform.position;
        }
        
        set
        {
            Debug.LogError("ZMIENIONO POZYCJĘ DOMU");
            transform.position = value;
        }
    }
}