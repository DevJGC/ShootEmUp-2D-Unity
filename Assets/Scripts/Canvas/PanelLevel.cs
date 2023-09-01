using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelLevel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textLevel;
    public int level;

    void Start()
    {
        // sinc textLevel.text to level + level text
        textLevel.text = "NIVEL " + level;

    }


    void Update()
    {
        
    }

    private void OnEnable()
    {
        // sinc textLevel.text to level + level text
        textLevel.text = "NIVEL " + level;
    }
}
