using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelLevel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textLevel; //  text level
    public int level; // level

    void Start()
    {
        // sincroniza panel level con level + text level
        textLevel.text = "NIVEL " + level;

    }


    void Update()
    {
        
    }

    // Cada vez que se activa sincroniza nivel con text level
    private void OnEnable()
    {
        // sinc textLevel.text to level + level text
        textLevel.text = "NIVEL " + level;
    }
}
