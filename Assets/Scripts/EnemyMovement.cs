using System.Collections;
using UnityEngine.AI;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform goal;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator anim;
    [SerializeField] private float health;

    private void Start()
    {
        health = 100f;
        agent.destination = goal.position;
        agent.speed = 2f;
    }

    public void TakeDamage(float damage)
    {
        if (health - damage < 1)
        {
            agent.speed = 0f;
            anim.SetBool("Dead", true);
        }
        else
        {
            return;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Goal"))
        {
            agent.speed = 0f;
            anim.SetBool("isReached", true);
        }
    }
}
