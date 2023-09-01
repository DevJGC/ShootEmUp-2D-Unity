using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesPlayer : MonoBehaviour
{
    public int lives; // vidas del jugador
    [SerializeField] GameObject[] livesIcons; // iconos de vidas canvas

    // sound
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioGameOver;

    [SerializeField] GameManager gameManager; // game manager

    void Start()
    {

    }


    void Update()
    {
        // press space to lose life
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    LoseLife();
        //}

    }

    // Método para perder una vida.
    public void LoseLife()
    {
        lives--;
        livesIcons[lives].SetActive(false);
        if (lives == 0)
        {
            GameOver();
        }
    }

    // Método para añadir una vida.
    public void AddLife()
    {
        if (lives < 3)
        {
            lives++;
            livesIcons[lives - 1].SetActive(true);
        }
    }

    // Game Over
    private void GameOver()
    {
        // play gameover
        audioSource.PlayOneShot(audioGameOver);
        // destroy player
        gameManager.DestroyPlayer();

    }


}    