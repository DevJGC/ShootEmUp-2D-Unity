using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefab;
    [SerializeField] float spawnTime = 2f;
    [SerializeField] float spawnDelay = 3f;

    void Start()
    {
        // move up and down dotween aleatory
        transform.DOMoveY(5f, 1.6f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine).SetId("SpawnerMovement");

        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }

    void Update()
    {
        
    }

    void Spawn()
    {
        int enemyIndex = Random.Range(0, enemyPrefab.Length);
        Instantiate(enemyPrefab[enemyIndex], transform.position, transform.rotation);
    }

    private void OnDisable()
    {
        // Detener el Invoke
        CancelInvoke("Spawn");

        // Detener el movimiento DOTween
        DOTween.Kill("SpawnerMovement");
    }

}
