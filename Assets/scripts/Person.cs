using UnityEngine;
using UnityEngine.AI;

public class Person : MonoBehaviour 
{
    [SerializeField]
    House house;
    [SerializeField]
    Job job;
    [SerializeField]
    float money;

    NavMeshAgent navMeshAg;

    void Start()
    {
        navMeshAg = GetComponent<NavMeshAgent>();
    }
}