using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // sound play
    [SerializeField] AudioSource audioSource;
    // sound button
    [SerializeField] AudioClip soundButton;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    // Sonido al pulsar el botón de jugar
    public void PlayGame()
    {
        // play sound button
        audioSource.PlayOneShot(soundButton);
        Invoke("TimetoPlay", 1f);
    }

    // Va al juego
    void TimetoPlay()
    {
        SceneManager.LoadScene("GamePlay");
    }

    // Sale del juego
    public void ExitGame()
    {
        Application.Quit();
    }
}
