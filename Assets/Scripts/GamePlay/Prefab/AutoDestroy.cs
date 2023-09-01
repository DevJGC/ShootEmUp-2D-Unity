using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] private float timeToDestroy = 1f;

    SoundExplosion soundExplosion;

    [SerializeField] private GameObject[] items;

    // is Ship
    [SerializeField] private bool isShip = false;
    
    void Start()
    {
        Invoke("AutoDestroySelf", timeToDestroy);
        // find object with tag "SoundExplosion"
        soundExplosion = GameObject.FindWithTag("Sounds").GetComponent<SoundExplosion>();
        // play sound explosion
        soundExplosion.PlaySoundExplosion();
        // if numero aleatorio 1 a 100 solo 20% de probabilidad
        int random = Random.Range(1, 101);
        if (random <= 15 && isShip)
        {
            LaunchItem();
        }


    }


    void Update()
    {
        
    }

    private void AutoDestroySelf()
    {
        
        Destroy(gameObject);
    }

    // genera aleatoriamente un item
    private void LaunchItem()
    {
        // random 0, 1, 2
        int random = Random.Range(0, 4);
        // if random == 0 return
        if (random == 0)
        {
            return;
        }
        // instantiate item
        Instantiate(items[random - 1], transform.position, Quaternion.identity);
    }
}
