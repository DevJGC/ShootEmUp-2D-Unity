using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextType : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private float typingSpeed = 0.1f; // puedes ajustar este valor para cambiar la velocidad de escritura
    [SerializeField] private string fullText; // Texto completo que deseas mostrar
    private string currentText = ""; // Texto actual en la UI

    // sounds
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    void Start()
    {
        fullText = textMeshProUGUI.text;
        textMeshProUGUI.text = ""; // Comienza con el texto vacío
        StartCoroutine(TypeText());
    }

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
        // Aquí puedes poner cualquier lógica de actualización si es necesario
    }
}
