using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManagerInstance;

    [SerializeField] int score;
    [SerializeField] TextMeshProUGUI scoreText;
    //[SerializeField] TextMesh recordText;

    private void Awake()
    {
        scoreManagerInstance = this;
    }

    private void Start()
    {
        
        scoreText.text = score.ToString();
        //    int recordTemp = PlayerPrefs.GetInt("record");
        //    recordText.text = "Record: " + recordTemp.ToString();
    }

    public void AddScore(int s)
    {
        score += s;
        scoreText.text = score.ToString();
    }

    //public void CheckRecord()
    //{
    //    if (score > PlayerPrefs.GetInt("record"))
    //    {
    //        PlayerPrefs.SetInt("record", score);
    //    }
    //}
}