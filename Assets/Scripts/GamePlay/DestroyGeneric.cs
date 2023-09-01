using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGeneric : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    // Destruye todo lo que es layer 6  (enemigos)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            // destroy the gameObject
            Destroy(gameObject);
        }
    }

}
