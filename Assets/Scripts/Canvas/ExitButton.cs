using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ExitButton : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {

    }

    public void ExitGame()
    {
        // kill all dotween
        DOTween.KillAll();
        // load scene game play
        SceneManager.LoadScene("Menu");
    }
}
