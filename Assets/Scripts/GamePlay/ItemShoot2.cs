using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShoot2 : MonoBehaviour
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
            Instantiate(healthUpParticle, transform.position, Quaternion.identity);
            // playershoot add shoot
            gameManager.Shoot2Active();
            // destroy item
            Destroy(gameObject);
        }
    }
}
