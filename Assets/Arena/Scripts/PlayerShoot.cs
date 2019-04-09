using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float bulletSpeed = 1000f;
    public float timer;
    public float timeBetweenBullets = 0.2f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public AudioClip attackClip;
    AudioSource audio;


    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            audio.clip = attackClip;
            audio.Play();
            Fire();
        }
    }

    private void Fire()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
        Vector3 bVel = bulletSpawn.transform.forward.normalized;
        bullet.GetComponent<Rigidbody>().AddForce(bVel * bulletSpeed);
        Destroy(bullet, 3.0f);
    }
}