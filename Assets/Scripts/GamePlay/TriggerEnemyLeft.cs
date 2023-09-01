using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemyLeft : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    // ontrigger enter 2d layer 6 destroy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            // destroy the gameObject
            Destroy(collision.gameObject);
        }
    }
}
