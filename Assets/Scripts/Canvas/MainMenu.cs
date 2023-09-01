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

    public void PlayGame()
    {
        // play sound button
        audioSource.PlayOneShot(soundButton);
        Invoke("TimetoPlay", 1f);
    }

    void TimetoPlay()
    {
        // load scene game play
        SceneManager.LoadScene("GamePlay");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
