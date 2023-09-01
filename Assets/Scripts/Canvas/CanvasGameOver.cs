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

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // kill all
        DOTween.KillAll();
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
        // kill all
        DOTween.KillAll();
    }
}
