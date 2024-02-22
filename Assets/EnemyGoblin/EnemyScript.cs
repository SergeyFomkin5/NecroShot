using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public List<Transform> PatrolPoints;

    public PlayerController Player;

    private bool PlayerIsHitByRaycast;

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
        CheckPlayerInView();
        
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

    private void CheckPlayerInView()
    {
        var direction = Player.transform.position - transform.position;

        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
        {
            if(hit.collider.gameObject == Player.gameObject)
            {
                PlayerIsHitByRaycast = true;
            }
            else
            {
                PlayerIsHitByRaycast = false;
            }
        }
        else
        {
            PlayerIsHitByRaycast = false;
        }

        NewPatrolPoint();
    }


}
