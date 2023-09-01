using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject shoot1; // punto de disparo y animacion // disparo especial superior
    [SerializeField] private GameObject shoot2; // punto de disparo y animacion // disparo central
    [SerializeField] private GameObject shootBomb; // punto de disparo y animacion // disparo bomba

    [SerializeField] public bool shoot1Enabled = false; // habilitar disparo especial superior
    [SerializeField] public bool shootBoombEnabled = false; // habilitar disparo bomba

    // prefabs
    [SerializeField] private GameObject shoot1Prefab; // prefab de la bala
    [SerializeField] private GameObject shoot2Prefab; // prefab de la bala
    [SerializeField] private GameObject shootBombPrefab; // prefab de la bala
    
    void Start()
    {
        
    }
    

    void Update()
    {
        // mientras se pulsa el botón izquierdo del ratón, se ejecuta la animación de disparo Shoot2
        if (Input.GetMouseButton(0))
        {
            shoot2.gameObject.GetComponent<Animator>().SetTrigger("Shoot");

            // si el disparo especial superior está habilitado, se ejecuta la animación de disparo Shoot1
            if (shoot1Enabled)
            {
                shoot1.gameObject.GetComponent<Animator>().SetTrigger("Shoot");
            }
        }

        // mientras se pulsa el botón derecho del ratón, se ejecuta la animación de disparo ShootBomb
        if (Input.GetMouseButtonDown(1) && (shootBoombEnabled))
        {
            shootBomb.gameObject.GetComponent<Animator>().SetTrigger("Shoot");
            ShootBomb();
        }

    }
    
    public void Shoot1()
    {
        Instantiate(shoot1Prefab, shoot1.transform.position, shoot1.transform.rotation);
    }

    public void Shoot2()
    {    
        Instantiate(shoot2Prefab, shoot2.transform.position, shoot2.transform.rotation);
    }

    private void ShootBomb()
    {
        Instantiate(shootBombPrefab, shootBomb.transform.position, shootBomb.transform.rotation);
    }

    // enable bool shoot1Enabled
    public void EnableShoot1()
    {
        shoot1Enabled = true;
    }

    // disable bool shoot1Enabled
    public void DisableShoot1()
    {
        shoot1Enabled = false;
    }

    // enable bool shootBoombEnabled
    public void EnableShootBoomb()
    {
        shootBoombEnabled = true;
    }

    // disable bool shootBoombEnabled
    public void DisableShootBoomb()
    {
        shootBoombEnabled = false;
    }



}
