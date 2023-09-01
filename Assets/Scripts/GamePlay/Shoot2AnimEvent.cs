using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot2AnimEvent : MonoBehaviour
{
    // eventos de animacion
    [SerializeField] private PlayerShoot playerShoot; //    reference player shoot (Script)

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //  Método para disparar 2
    public void Shoot2()
    {
        playerShoot.Shoot2();
    }

    //  Método para disparar 1
    public void Shoot1()
    {
        playerShoot.Shoot1();
    }
}
