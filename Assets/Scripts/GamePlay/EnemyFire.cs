using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform firePoint2;
    [SerializeField] private Transform firePoint3;

    [SerializeField] private float fireRate;

    // sound
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClipFire;

    [SerializeField] bool noFire;// false dispara


    void Start()
    {
        // find audiosource object tag Sounds
        audioSource = GameObject.FindGameObjectWithTag("Sounds").GetComponent<AudioSource>();
        
        if (noFire == false)
        {
            InvokeRepeating("Fire", 0f, fireRate);
        }
    }


    void Update()
    {

    }

    void Fire()
    {
        Instantiate(enemyBullet, firePoint.position, firePoint.rotation);
        Instantiate(enemyBullet, firePoint2.position, firePoint2.rotation);
        Instantiate(enemyBullet, firePoint3.position, firePoint3.rotation);
        // play sound
        audioSource.PlayOneShot(audioClipFire);
    }
}
