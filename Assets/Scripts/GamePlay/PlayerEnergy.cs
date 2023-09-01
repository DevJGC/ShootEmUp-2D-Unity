using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerEnergy : MonoBehaviour
{
    [SerializeField] public float energy = 10f; // Energía del jugador

    // reference image canvas fill
    [SerializeField] private Image energyBar;

    // reference LivesPlayer
    [SerializeField] private LivesPlayer livesPlayer;


    // referencia animator
    [SerializeField] private Animator animatorPlayer;

    // sound
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClipHit;
    [SerializeField] private AudioClip audioClipExplosion;
    [SerializeField] private AudioClip audioClipLose;

    // particle system
    [SerializeField] private ParticleSystem particleSystemHumo;

    // reference box collider
    [SerializeField] private CircleCollider2D circleCollider2D;

    // vector 2 player ini position
    [SerializeField] private Vector2 playerIniPosition;

    void Start()
    {
        // sync energy bar with energy
        energyBar.fillAmount = energy;

        transform.DOMoveX(0f, 1f); // dotween move to right al inicio
    }

    void Update()
    {
        
    }

    // añade energia
    public void AddEnergy(float amount)
    {
        energy += amount;
        energyBar.fillAmount = energy/10;
    }

    // resta energia
    public void RemoveEnergy(float amount)
    {
        energy -= amount;
        energyBar.fillAmount = energy/10;
        // play sound
        audioSource.PlayOneShot(audioClipHit);


        // if energy =<0 
        if (energy <= 0)
        {
            PlayerDead();
        }
    }
    
    // consulta energia
    public float GetEnergy()
    {
        return energy;
    }

    // Si el player toca con el layer Enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // si colisiona con un enemigo
        if (collision.gameObject.layer == 3)
        {
            // añade energia
            RemoveEnergy(collision.gameObject.GetComponent<EnemyEnergy>().enemyForce);
            // destruye el enemigo
            //Destroy(collision.gameObject);
            // animatorPlayer setTrigger Hit
            animatorPlayer.SetTrigger("Hit");
        }
    }

    // player dead
    private void PlayerDead()
    {
        // livesPlayer lose life
        livesPlayer.LoseLife();
        // animatorPlayer setTrigger Dead
        animatorPlayer.SetTrigger("Dead");
        // play sound
        audioSource.PlayOneShot(audioClipExplosion);
        // particle system humo play
        particleSystemHumo.Stop();
        // circle collider 2d disable
        circleCollider2D.enabled = false;
        Invoke("MoveLeft", 1f);
    }
    
    // move player left
    private void MoveLeft()
    {
        // set position to playerIniPosition
        transform.position = playerIniPosition;
        // respawn player
        RespawnPlayer();
    }

    // respawn player
    private void RespawnPlayer()
    {
        // animatorPlayer setTrigger Respawn
        animatorPlayer.SetTrigger("Respawn");
        Invoke("MoveRight", 1f);
    }

    // move player right al iniciar nivel
    private void MoveRight()
    {
        // lose sound
        audioSource.PlayOneShot(audioClipLose);
        // dotween move to right 2 seconds and complete callback
        transform.DOMoveX(0f, 1f).OnComplete(ColisionadorTrigger);
        // particle system humo play
        particleSystemHumo.Play();

        // energy = 1
        energy = 10f;
        // sync energy bar with energy
        energyBar.fillAmount = energy/10;
    }

    // colisionador trigger con retardo
    private void ColisionadorTrigger()
    {
        Invoke("ColisionadorActive", 1f);
    }

    // colisionador active
    private void ColisionadorActive()
    {
        // circle collider 2d disable
        circleCollider2D.enabled = true;
    }

    // restaurar energia
    public void RestaurarEnergia()
    {
        energy = 10f;
        // sync energy bar with energy
        energyBar.fillAmount = energy / 10;
    }
}
