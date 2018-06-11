using UnityEngine;
using UnityEngine.AI;

public class Person : MonoBehaviour
{
    public enum STANCE { WORKING, SLEEPING, PARTYYEAH, MOVING, EATING, }
    public STANCE stance;

    enum PURPOSE { WORK, SLEEP, HANGOUT }
    PURPOSE purpose;

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
        job.StartWork += Job_StartWork;
        job.StopWork += Job_StopWork;

        job.SubscribeEvents();
    }

    private void Update()
    {
        switch (stance)
        {
            case STANCE.MOVING:
                Move();
                break;
        }
    }

    private void Job_StopWork()
    {
        navMeshAg.destination = house.transform.position;
        stance = STANCE.MOVING;
        purpose = PURPOSE.WORK;
    }

    private void Job_StartWork()
    {
        navMeshAg.destination = job.workplace.transform.position;
        stance = STANCE.MOVING;
        purpose = PURPOSE.WORK;
    }

    private void Move()
    {
        if (Vector3.Distance(navMeshAg.destination, transform.position) < 0.1f)
        {
            stance = STANCE.WORKING;
        }
    }
}