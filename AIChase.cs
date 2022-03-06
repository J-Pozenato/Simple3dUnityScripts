using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class AIChase : MonoBehaviour
{
    public enum AISTATE { PATROL = 0, CHASE = 1, ATTACK = 2 };
    private NavMeshAgent thisAgent = null;
    private Transform player = null;

    public AISTATE CurrentState
    {
        get { return _CurrentState; }
        set
        {
            StopAllCoroutines();
            _CurrentState = value;

            switch (CurrentState)
            {
                case AISTATE.PATROL:
                    StartCoroutine(StatePatrol());
                    break;

                case AISTATE.CHASE:
                    StartCoroutine(StateChase());
                    break;

                case AISTATE.ATTACK:
                    StartCoroutine(StateAttack());
                    break;
            }
        }
    }

    [SerializeField]
    private AISTATE _CurrentState = AISTATE.PATROL;

    private void Awake()
    {
        thisAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    private void Start()
    {
        CurrentState = AISTATE.PATROL;
    }

    public IEnumerator StateChase()
    {
        float attackDistance = 2f;

        while (CurrentState == AISTATE.CHASE)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < attackDistance)
            {
                CurrentState = AISTATE.ATTACK;
                yield break;
            }

            thisAgent.SetDestination(player.transform.position);
            yield return null;
        }
    }

    public IEnumerator StateAttack()
    {
        float attackDistance = 2f;


        while (CurrentState == AISTATE.ATTACK)
        {
            if (Vector3.Distance(transform.position, player.transform.position) > attackDistance)
            {
                CurrentState = AISTATE.CHASE;
                yield break;
            }

            print("Attack!!");
            thisAgent.SetDestination(player.transform.position);
            yield return null;
        }
    }

    public IEnumerator StatePatrol()
    {
        GameObject[] Waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        GameObject CurrentWaypoint = Waypoints[Random.Range(0, Waypoints.Length)];
        float targetDistance = 2f;

        while (CurrentState == AISTATE.PATROL)
        {
            thisAgent.SetDestination(CurrentWaypoint.transform.position);

            if (Vector3.Distance(transform.position, CurrentWaypoint.transform.position) < targetDistance)
            {
                CurrentWaypoint = Waypoints[Random.Range(0, Waypoints.Length)];
            }

            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        CurrentState = AISTATE.CHASE;
    }
}
