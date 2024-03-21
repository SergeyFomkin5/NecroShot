using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public List<Transform> PatrolPoints;

    public float viewAngle;

    public float Health = 100;

    public float AttackSpeed;

    public float WalkSpeed;

    public float Damage;

    public PlayerController Player;

    public Transform PlayerPosition;

    private bool PlayerIsHitByRaycast;

    RaycastHit hit;


    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        PlayerPosition = GameObject.Find("Player").transform;
        
    }

    void Start()
    {
        Componentlinks();

        UpdatePatrolPoint();
    }


    // Update is called once per frame
    void Update()
    {
        Patroling();
    }

    private void Componentlinks()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = WalkSpeed;
    }

    private void Patroling()
    {
        UpdatePatrolPoint();
        CheckPlayerInView();
        PlayerChasing();
    }

    private void UpdatePatrolPoint()
    {
        if (navMeshAgent.remainingDistance == 0 && !PlayerIsHitByRaycast)
        {
            PickNewPatrolPoints();
        }
    }

    private void PickNewPatrolPoints()
    {
        navMeshAgent.SetDestination((PatrolPoints[Random.Range(0, PatrolPoints.Count)]).position);
    }

    private void CheckPlayerInView()
    {
        var direction = Player.transform.position - transform.position;
        PlayerIsHitByRaycast = false;

        RaycastHit hit;

        if (Vector3.Angle(transform.forward, direction) < viewAngle)
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

    private void PlayerChasing()
    {
        if (PlayerIsHitByRaycast)
        {
            navMeshAgent.destination = Player.transform.position;
        }
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        Debug.Log("Hit");
        if (Health <= 0) 
        {
            Destroy(gameObject);
        }
    }

   

    


}
