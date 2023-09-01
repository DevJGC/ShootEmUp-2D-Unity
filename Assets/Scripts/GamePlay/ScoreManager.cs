using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManagerInstance; // singleton

    [SerializeField] int score;     // score
    [SerializeField] TextMeshProUGUI scoreText;     // score text

    private void Awake()
    {
        scoreManagerInstance = this; // singleton
    }

    private void Start()
    {
        scoreText.text = score.ToString(); // score text
    }

    //  Método para añadir puntos al marcador.
    public void AddScore(int s)
    {
        score += s;
        scoreText.text = score.ToString();
    }
}