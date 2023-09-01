using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextType : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private float typingSpeed = 0.1f; // Ajustar este valor para cambiar la velocidad de escritura
    [SerializeField] private string fullText; // Texto completo a mostrar
    private string currentText = ""; // Texto actual en la UI

    // sounds
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    
    void Start()
    {
        // actualiza texto canvas y llama a la corrutina
        fullText = textMeshProUGUI.text;
        textMeshProUGUI.text = ""; // Comienza con el texto vacío
        StartCoroutine(TypeText());
    }

    // Corrutina para escribir el texto letra por letra
    IEnumerator TypeText()
    {
        yield return new WaitForSeconds(3); // Espera 2 segundos

        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i); // Actualiza el texto actual con una letra adicional
            textMeshProUGUI.text = currentText + "|"; // Añade el cursor al final

            yield return new WaitForSeconds(typingSpeed); // Espera un tiempo antes de añadir la siguiente letra
            // play sound
            audioSource.PlayOneShot(audioClip);
        }
       
        textMeshProUGUI.text = currentText; // Elimina el cursor al final cuando haya terminado
    }

    void Update()
    {
        // Para la corrutina y muestra el texto completo al pulsar la barra espaciadora
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    StopAllCoroutines(); // Detiene la corrutina
        //    textMeshProUGUI.text = fullText; // Muestra el texto completo
        //}
    }
}
