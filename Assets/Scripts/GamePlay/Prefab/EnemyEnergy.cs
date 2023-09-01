using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEnergy : MonoBehaviour
{
    public float enemyForce = 1f; // Energ�a del enemigo

    [SerializeField] GameObject prefabExplosionShip; // Prefab de la explosi�n de la nave
    [SerializeField] int scoreEnemy; // Puntuaci�n del enemigo

    public bool isBoss = false; // Variable para determinar si el enemigo es un Boss

    void Start()
    {

    }

    void Update()
    {

    }

    //  Cuando colisiona con el Layer Player o con el Layer Weapon
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)    
        {
            // resta ForceWeapon force a enemyForce
            enemyForce -= collision.gameObject.GetComponent<ForceWeapon>().force;
            // check enemyForce
            CheckEnemyForce();

            // Verifica primero si el objeto tiene el componente 'shoot'
            shoot shootComponent = collision.gameObject.GetComponent<shoot>();

            // Si el componente existe, entonces verifica si 'laserOrBomb' es verdadero
            if (shootComponent != null && shootComponent.laserOrBomb)
            {
                Camera mainCamera = Camera.main; // Obt�n la c�mara principal
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Encuentra todos los enemigos
                //  Recorre todos los enemigos
                foreach (GameObject enemy in enemies)
                {
                    EnemyEnergy enemyEnergyComponent = enemy.GetComponent<EnemyEnergy>(); // Obt�n el componente EnemyEnergy

                    Vector3 viewportPos = mainCamera.WorldToViewportPoint(enemy.transform.position); // Verifica si el enemigo est� dentro de la vista de la c�mara
                    // Verifica si el enemigo est� dentro de la vista de la c�mara
                    if (viewportPos.x >= 0 && viewportPos.x <= 1 && viewportPos.y >= 0 && viewportPos.y <= 1)
                    {
                        // Si el enemigo es un Boss
                        if (enemyEnergyComponent && enemyEnergyComponent.isBoss)
                        {
                            // Por ejemplo, reduce su salud en una cantidad menor, digamos un 20% de su salud m�xima.
                            enemyEnergyComponent.enemyForce -= (enemyEnergyComponent.enemyForce * 0.20f);
                            enemyEnergyComponent.CheckEnemyForce();
                        }
                        else
                        {
                            // instancia la explosi�n
                            Instantiate(prefabExplosionShip, enemy.transform.position, Quaternion.identity);
                            // a�ade scoreEnemy a ScoreManager
                            ScoreManager.scoreManagerInstance.AddScore(scoreEnemy);
                            // destruye el gameObject
                            Destroy(enemy);
                        }
                    }
                }

                // Busca GameManager y sacude la c�mara
                GameObject.Find("GameManager").GetComponent<GameManager>().ShakeCamera();
            }
        }
    }

    // check enemyForce and destroy gameObject
    private void CheckEnemyForce()
    {
        if (enemyForce <= 0)
        {
            // instantiate explosion
            Instantiate(prefabExplosionShip, transform.position, Quaternion.identity);
            // add scoreEnemy to ScoreManager
            ScoreManager.scoreManagerInstance.AddScore(scoreEnemy);
            // destroy the gameObject
            Destroy(gameObject);
        }
    }
}

