using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBomb : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private GameObject healthUpParticle;

    void Start()
    {
        // find tag gamecontroller
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

    }


    void Update()
    {

    }

    // ontriggerenter 2d tag player destroy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // healthupparticle instantiate
            Instantiate(healthUpParticle, transform.position, Quaternion.identity);
            // playershoot add shoot
            gameManager.BoombActive();
            // destroy item
            Destroy(gameObject);
        }
    }
}