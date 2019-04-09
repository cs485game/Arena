using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class EnemyAttack : MonoBehaviour
    {
        public float timeBetweenAttacks = 0.5f;
        public int attackDamage = 10;


        //Animator anim;
        GameObject player;
        Transform enemy;
        PlayerHealth playerHealth;
        EnemyHealth enemyHealth;
        bool playerInRange;
        float timer;
        public AudioClip attackClip;
        AudioSource audio;


        void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            enemy = this.GetComponent<Transform>();
            playerHealth = player.GetComponent<PlayerHealth>();
            enemyHealth = GetComponent<EnemyHealth>();
            audio = GetComponent<AudioSource>();
            //anim = GetComponent<Animator>();
        }


        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == player)
            {
                playerInRange = true;
            }
        }


        void OnTriggerExit(Collider other)
        {
            if (other.gameObject == player)
            {
                playerInRange = false;
            }
        }


        void Update()
        {
            timer += Time.deltaTime;

            if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
            {
                audio.clip = attackClip;
                audio.Play();
                Attack();
            }

            if (playerHealth.currentHealth <= 0)
            {
                //anim.SetTrigger("PlayerDead");
            }
        }


        void Attack()
        {
            timer = 0f;

            if (playerHealth.currentHealth > 0)
            {
                playerHealth.TakeDamage(attackDamage);
                Rigidbody playerRB = player.GetComponent<Rigidbody>();
                playerRB.AddForce((player.transform.position - enemy.transform.position) * 50f, ForceMode.Impulse);
            }
        }
    }
}