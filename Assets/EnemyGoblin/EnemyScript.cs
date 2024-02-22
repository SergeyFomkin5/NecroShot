using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public List<Transform> PatrolPoints;

    public float viewAngle;

    public PlayerController Player;

    private bool PlayerIsHitByRaycast;

    RaycastHit hit;


    private NavMeshAgent _navMeshAgent;
    
    void Start()
    {
        Componentlinks();

        UpdatePatrolPoint();
    }


    // Update is called once per frame
    void Update()
    {
        UpdatePatrolPoint();
        CheckPlayerInView();
        PlayerStalking();
    }

    private void Componentlinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void UpdatePatrolPoint()
    {
        if (_navMeshAgent.remainingDistance == 0 && !PlayerIsHitByRaycast)
        {
            PickNewPatrolPoints();
        }
    }

    private void PickNewPatrolPoints()
    {
        _navMeshAgent.SetDestination((PatrolPoints[Random.Range(0, PatrolPoints.Count)]).position);
    }

    private void CheckPlayerInView()
    {
        var direction = Player.transform.position - transform.position;
        PlayerIsHitByRaycast = false;

        RaycastHit hit;

        if(Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == Player.gameObject)
                {
                    PlayerIsHitByRaycast = true;
                }
            }
            
        }
        

       

        UpdatePatrolPoint();
    }

    private void PlayerStalking()
    {
        if (PlayerIsHitByRaycast)
        {
            _navMeshAgent.destination = Player.transform.position;
        }
    }


}
