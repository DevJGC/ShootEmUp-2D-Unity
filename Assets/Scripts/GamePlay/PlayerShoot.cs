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
    [SerializeField] private GameObject shoot2Prefab; // prefab de la bala 2
    [SerializeField] private GameObject shootBombPrefab; // prefab de bomba
    
    void Start()
    {
        
    }
    
    void Update()
    {
        // mientras se pulsa el bot�n izquierdo del rat�n, se ejecuta la animaci�n de disparo Shoot2
        if (Input.GetMouseButton(0))
        {
            shoot2.gameObject.GetComponent<Animator>().SetTrigger("Shoot");

            // si el disparo especial superior est� habilitado, se ejecuta la animaci�n de disparo Shoot1
            if (shoot1Enabled)
            {
                shoot1.gameObject.GetComponent<Animator>().SetTrigger("Shoot");
            }
        }

        // mientras se pulsa el bot�n derecho del rat�n, se ejecuta la animaci�n de disparo ShootBomb
        if (Input.GetMouseButtonDown(1) && (shootBoombEnabled))
        {
            shootBomb.gameObject.GetComponent<Animator>().SetTrigger("Shoot");
            ShootBomb();
        }
    }

    // M�todo para disparar
    public void Shoot1()
    {
        Instantiate(shoot1Prefab, shoot1.transform.position, shoot1.transform.rotation);
    }

    // M�todo para disparar 2
    public void Shoot2()
    {    
        Instantiate(shoot2Prefab, shoot2.transform.position, shoot2.transform.rotation);
    }

    // M�todo para disparar bomba
    private void ShootBomb()
    {
        Instantiate(shootBombPrefab, shootBomb.transform.position, shootBomb.transform.rotation);
    }

    // Activa disparo especial
    public void EnableShoot1()
    {
        shoot1Enabled = true;
    }

    // Desactiva disparo especial
    public void DisableShoot1()
    {
        shoot1Enabled = false;
    }

    // Activa disparo bomba
    public void EnableShootBoomb()
    {
        shootBoombEnabled = true;
    }

    //  Desactiva disparo bomba
    public void DisableShootBoomb()
    {
        shootBoombEnabled = false;
    }
}
