using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShield : MonoBehaviour
{
    [SerializeField] private GameManager gameManager; // reference gamemanager

    [SerializeField] private GameObject healthUpParticle;   // reference healthupparticle (prefab)

    void Start()
    {
        // find tag gamecontroller
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

    }


    void Update()
    {

    }

    // Si el jugador toca el item escudo
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // healthupparticle instantiate
            Instantiate(healthUpParticle, transform.position, Quaternion.identity);
            // playershoot add shoot
            gameManager.ShieldActive();
            // destroy item
            Destroy(gameObject);
        }
    }
}