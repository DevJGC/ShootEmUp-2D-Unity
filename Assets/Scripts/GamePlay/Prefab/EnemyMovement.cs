using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Vector2 enemyMov; // enemy movement

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(enemyMov * Time.deltaTime); // enemy movement en 2 vectores

    }
}
