using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent MeshAgent;
    public Transform Target;
    float distanceToTarget;
    public float DamagePlayer = 5;
    public float RetreatDistance = 8;
    public float StartTimeBtwShoots;
    private float timeBtwShoots;

    PlayerHealth playerHealth;

    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        MeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        MeshAgent.SetDestination(Target.position);
        distanceToTarget = Vector3.Distance(Target.position, transform.position);
        if (distanceToTarget <= MeshAgent.stoppingDistance)
        {
            AttackPlayer();
        }
        if (distanceToTarget <= RetreatDistance)
        {
            RetreatEnemy();
        }
    }

    private void RetreatEnemy()
    {
        Debug.Log("Back");
        transform.position = Vector3.MoveTowards(transform.position, Target.position, -MeshAgent.speed * Time.deltaTime);
    }

    private void AttackPlayer()
    {
        if (timeBtwShoots <= 0)
        {
            playerHealth.CurrentHealth -= DamagePlayer;
            timeBtwShoots = StartTimeBtwShoots;
        }
        else
        {
            timeBtwShoots -= Time.deltaTime;
        }
    }
}
