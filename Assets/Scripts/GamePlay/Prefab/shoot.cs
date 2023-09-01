using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class shoot : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;


    [SerializeField] private float speed = 10f; // velocidad de la bala

    [SerializeField] float timeToDestroy;

    // sound
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip laserSound;
    [SerializeField] private AudioClip bombSound;


    [SerializeField] public bool laserOrBomb; // false = laser, true = bomb

    [SerializeField] GameObject explosionPrefab;


    void Start()
    {
        if (laserOrBomb)
        {
            audioSource.PlayOneShot(bombSound);
        } else
        {
            audioSource.PlayOneShot(laserSound);
        }
        Destroy(gameObject, timeToDestroy);
    }

    
    void Update()
    {
        // add impulse to the bullet
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
    }

    // ontrigger enter 2d layer 3
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            // prefab explosion
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            // destroy the bullet
            Destroy(gameObject);
        }
    }
}
