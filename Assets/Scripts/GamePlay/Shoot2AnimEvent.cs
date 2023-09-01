using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot2AnimEvent : MonoBehaviour
{
    [SerializeField] private PlayerShoot playerShoot;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot2()
    {
        playerShoot.Shoot2();
    }

    public void Shoot1()
    {
        playerShoot.Shoot1();
    }

}
