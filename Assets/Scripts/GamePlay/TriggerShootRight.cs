using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerShootRight : MonoBehaviour
{
    // destruye todas las balas que salen por la derecha
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // Si la bala sale por la parte derecha de la pantalla, se destruye. Utilizo TAG y no LAYER para evitar destruir Player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shoot") || collision.CompareTag("Bomb"))
        {
            Destroy(collision.gameObject);
        }
    }

    // Por si acaso alguna bala no se destruye por su velocidad nos aseguramos
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Shoot") || collision.CompareTag("Bomb"))
        {
            Destroy(collision.gameObject);
        }
    }
}
