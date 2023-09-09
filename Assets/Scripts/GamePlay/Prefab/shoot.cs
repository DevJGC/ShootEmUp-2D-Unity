using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class shoot : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb; // rigidbody 2d


    [SerializeField] private float speed = 10f; // velocidad de la bala

    [SerializeField] float timeToDestroy; // time to destroy the bullet

    // sound
    [SerializeField] private AudioSource audioSource; // audio source
    [SerializeField] private AudioClip laserSound;  // laser sound
    [SerializeField] private AudioClip bombSound;   // bomb sound


    [SerializeField] public bool laserOrBomb; // false = laser, true = bomb

    [SerializeField] GameObject explosionPrefab;    // explosion prefab

    // Al iniciar la bala muestra sonido correspondiente y programa su destrucción
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

    
    void FixedUpdate()
    {
        // add impulse to the bullet
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
    }

    // ontrigger enter 2d layer 3 (enemy)
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
