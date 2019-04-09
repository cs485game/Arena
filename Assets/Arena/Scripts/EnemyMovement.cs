using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class EnemyMovement : MonoBehaviour
    {
        Transform player;
        CapsuleCollider enemy;
        PlayerHealth playerHealth;
        EnemyHealth enemyHealth;
        UnityEngine.AI.NavMeshAgent nav;
        public float speed = 3f;


        void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            playerHealth = player.GetComponent<PlayerHealth>();
            enemy = this.GetComponent<CapsuleCollider>();
            enemyHealth = GetComponent<EnemyHealth>();
            nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        }


        void Update()
        {
            if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
            {
                enemy.isTrigger = false;
                player = GameObject.FindGameObjectWithTag("Player").transform;
                nav.SetDestination(player.transform.position);
                transform.LookAt(player.transform);
                transform.position += transform.forward * speed * Time.deltaTime;
                enemy.isTrigger = true;
            }
            else
            {
                nav.enabled = false;
            }
        }
    }
}