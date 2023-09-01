using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemyLeft : MonoBehaviour
{
    // Destructor de todo lo que salga por la parte izquierda de la pantalla

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    // Destruye todo lo que sea Enemy del Layer 3
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            // destroy the gameObject
            Destroy(collision.gameObject);
        }
    }
}
