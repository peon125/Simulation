using UnityEngine;

public class Workplace : MonoBehaviour
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

    [SerializeField]
    Job[] jobsAvailable;
    [SerializeField]
    Job[] jobsTaken;
    [SerializeField]
    int workSince;
    [SerializeField]
    int workTo;
}