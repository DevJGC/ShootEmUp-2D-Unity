using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesPlayer : MonoBehaviour
{
    public int lives;
    [SerializeField] GameObject[] livesIcons;

    // sound
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioGameOver;

    [SerializeField] GameManager gameManager;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // press space to lose life
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoseLife();
        }

    }

    public void LoseLife()
    {
        lives--;
        livesIcons[lives].SetActive(false);
        if (lives == 0)
        {
            GameOver();
        }
    }

    public void AddLife()
    {
        if (lives < 3)
        {
            lives++;
            livesIcons[lives - 1].SetActive(true);
        }
    }
    
    private void GameOver()
    {
        // play gameover
        audioSource.PlayOneShot(audioGameOver);
        // destroy player
        gameManager.DestroyPlayer();

    }


}    