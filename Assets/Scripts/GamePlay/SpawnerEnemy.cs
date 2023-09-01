using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefab; // enemy prefab
    [SerializeField] float spawnTime = 2f; // spawn time
    [SerializeField] float spawnDelay = 3f; // spawn delay

    void Start()
    {
        // move up and down dotween aleatory
        transform.DOMoveY(5f, 1.6f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine).SetId("SpawnerMovement"); //  Con ID para cancelar el movimiento DOTween al desactivar el spawner

        InvokeRepeating("Spawn", spawnDelay, spawnTime); // InvokeRepeating (ojo!! el el InvokeRepeating sigue funcionando aunque se desactivel el objeto)
    }

    void Update()
    {
        
    }

    // Método para spawnear enemigos aleatoriamente (no siempre saldrá el mismo prefab)
    void Spawn()
    {
        int enemyIndex = Random.Range(0, enemyPrefab.Length); //  Random.Range (min, max) max no incluido
        Instantiate(enemyPrefab[enemyIndex], transform.position, transform.rotation);
    }

    //  Al desactivar cancelar el Invoke y el movimiento DOTween del spawner
    private void OnDisable()
    {
        // Detener el Invoke
        CancelInvoke("Spawn");

        // Detener el movimiento DOTween
        DOTween.Kill("SpawnerMovement");
    }
}
