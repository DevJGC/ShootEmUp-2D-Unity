using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerShootRight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // on trigger enter 2d tag Shoot and Bomb destroy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shoot") || collision.CompareTag("Bomb"))
        {
            Destroy(collision.gameObject);

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Shoot") || collision.CompareTag("Bomb"))
        {
            Destroy(collision.gameObject);

        }
    }


}
