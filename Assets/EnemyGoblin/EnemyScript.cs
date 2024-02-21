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
        _navMeshAgent = GetComponent<NavMeshAgent>();

        
    }


    // Update is called once per frame
    void Update()
    {
        if (_navMeshAgent.remainingDistance == 0)
        {
            _navMeshAgent.SetDestination((PatrolPoints[Random.Range(0, PatrolPoints.Count)]).position);
        }
    }


}
