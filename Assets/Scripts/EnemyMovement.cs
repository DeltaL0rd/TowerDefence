using System.Collections;
using UnityEngine.AI;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform goal;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator anim;
    [SerializeField] private float health;
    [SerializeField] private bool isHavingPowerUp;
    [SerializeField] private int powerUpID;
    [SerializeField] private GameObject[] powerups; //temp

    private void Start()
    {
        health = 100f;
        agent.destination = goal.position;
        agent.speed = 2f;

        int temp = Random.Range(0, 7);
        if (temp < 2)
        {
            isHavingPowerUp = true;
            powerUpID = temp;
        }
    }

    public void TakeDamage(float damage)
    {
         health -= damage;
        if (health < 1)
        {
            agent.speed = 0f;
            anim.SetBool("isDead", true);
            DropPowerUp();
            Invoke("HideBody", 3f);
        }
        else
        {
            return;
        }
    }
    private void DropPowerUp()
    {
        if (isHavingPowerUp)
        {
            powerups[powerUpID].SetActive(true);
            powerups[powerUpID].transform.localPosition = transform.localPosition;
        }
        else
        {
            return;
        }
    }
    private void HideBody()
    {
        gameObject.SetActive(false); 
    }

    public void WalkSlow()
    {
        agent.speed = 1f;
        anim.SetBool("isSlow", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Goal"))
        {
            agent.speed = 0f;
            anim.SetBool("isReached", true);
            GameManager.Instance.StartDamagingVillage();
        }
        else if (other.CompareTag("Bullet"))
        {
            TakeDamage(10f);
            Destroy(other.gameObject);
        }
    }
}
