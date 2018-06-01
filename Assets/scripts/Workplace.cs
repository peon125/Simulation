using UnityEngine;

public class Workplace : MonoBehaviour
{
    [SerializeField]
    Job[] jobsAvailable;
    [SerializeField]
    Job[] jobsTaken;
    [SerializeField]
    int workSince;
    [SerializeField]
    int workTo;
}