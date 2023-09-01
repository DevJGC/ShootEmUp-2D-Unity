using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] private float timeToDestroy = 1f; // time to destroy

    SoundExplosion soundExplosion; // reference sound explosion

    [SerializeField] private GameObject[] items;    // items para instanciar

    // is Ship
    [SerializeField] private bool isShip = false; // es la nave?

    // Invoca la destrucción del objeto
    void Start()
    {
        Invoke("AutoDestroySelf", timeToDestroy);
        // find object with tag "SoundExplosion"
        soundExplosion = GameObject.FindWithTag("Sounds").GetComponent<SoundExplosion>();
        // play sound explosion
        soundExplosion.PlaySoundExplosion();
        // if numero aleatorio 1 a 100 solo 15% de probabilidad
        int random = Random.Range(1, 101);
        if (random <= 15 && isShip)
        {
            LaunchItem(); // si es menor que 15, instancia objeto
        }


    }


    void Update()
    {
        
    }

    // Destruye el objeto
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
        // instantiate item aleatorio
        Instantiate(items[random - 1], transform.position, Quaternion.identity);
    }
}
