using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public List<Transform> PatrolPoints;

    public GameObject Enemy;

    RaycastHit hit;


    private NavMeshAgent _navMeshAgent;
    
    void Start()
    {
        Componentlinks();

        NewPatrolPoint();
    }


    // Update is called once per frame
    void Update()
    {
        NewPatrolPoint();
    }

    private void Componentlinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void NewPatrolPoint()
    {
        if (_navMeshAgent.remainingDistance == 0)
        {
            PickPatrolPoints();
        }
    }

    private void PickPatrolPoints()
    {
        _navMeshAgent.SetDestination((PatrolPoints[Random.Range(0, PatrolPoints.Count)]).position);
    }


}
