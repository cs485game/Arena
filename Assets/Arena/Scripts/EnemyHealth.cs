using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth = 1;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 1;
    public int damageTaken = 35;
    public AudioClip deathClip;


    //Animator anim;
    AudioSource enemyAudio;
    //ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;


    void Awake ()
    {
        //anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        //hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

        currentHealth = startingHealth;
    }


    void Update ()
    {
        if(isSinking)
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            this.capsuleCollider.isTrigger = true;
            TakeDamage(damageTaken);
            other.gameObject.SetActive(false);
            this.capsuleCollider.isTrigger = false;
        }
        if (other.gameObject.CompareTag("floor"));
        {
            //this.capsuleCollider.isTrigger = false;
            //this.capsuleCollider.isTrigger = true;
        }
    }

    public void TakeDamage (int amount)
    {
        if(isDead)
            return;

        //enemyAudio.Play ();

        currentHealth -= amount;
            
        //hitParticles.transform.position = hitPoint;
        //hitParticles.Play();

        if(currentHealth <= 0)
        {
            Death ();
        }
    }


    public void Death ()
    {
        this.gameObject.SetActive(false);
        isDead = true;

        capsuleCollider.isTrigger = false;

        //anim.SetTrigger ("Dead");
        ScoreManager.score += scoreValue;
        enemyAudio.clip = deathClip;
        enemyAudio.Play ();
        //float delay = 0f;
        //delay += delay + Time.deltaTime;
        //if (delay > 3f)
        
    }


    public void StartSinking ()
    {
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
        isSinking = true;
        ScoreManager.score += scoreValue;
        Destroy (gameObject, 2f);
    }
}
