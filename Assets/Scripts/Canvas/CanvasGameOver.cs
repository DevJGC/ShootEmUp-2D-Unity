using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class CanvasGameOver : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    // Reinicia Escena
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // kill all DotWeens
        DOTween.KillAll();
    }

    // Sale al menu
    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
        // kill all DotWeens
        DOTween.KillAll();
    }
}
