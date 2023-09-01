using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    [SerializeField] private GameObject enemyBullet; // enemy bullet
    [SerializeField] private Transform firePoint;   // fire point
    [SerializeField] private Transform firePoint2;  // fire point 2
    [SerializeField] private Transform firePoint3;  // fire point 3

    [SerializeField] private float fireRate;    // fire rate

    // sound
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClipFire;

    [SerializeField] bool noFire; // false dispara y true no dispara


    void Start()
    {
        // find audiosource object tag Sounds
        audioSource = GameObject.FindGameObjectWithTag("Sounds").GetComponent<AudioSource>();

        //  if noFire is false, invoke repeating fire
        if (noFire == false)
        {
            InvokeRepeating("Fire", 0f, fireRate);
        }
    }


    void Update()
    {

    }

    // fire function instantiate enemy bullet
    void Fire()
    {
        Instantiate(enemyBullet, firePoint.position, firePoint.rotation);
        Instantiate(enemyBullet, firePoint2.position, firePoint2.rotation);
        Instantiate(enemyBullet, firePoint3.position, firePoint3.rotation);
        // play sound
        audioSource.PlayOneShot(audioClipFire);
    }
}
