using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxSpeed = 1f; // velocidad general de movimiento
    [SerializeField] private Transform[] backgrounds; // array de todas las capas de fondo para el efecto parallax
    [SerializeField] private float[] parallaxScales; // los valores más bajos harán que la capa se mueva más lentamente
    private float[] spriteWidths; // Anchura de los sprites

    void Start()
    {
        if (backgrounds.Length != parallaxScales.Length)
        {
            Debug.LogError("Los arrays de fondos y escalas no coinciden en tamaño.");
            this.enabled = false; // Desactiva el script si hay un error
            return;
        }

        // Inicializar el array de anchuras
        spriteWidths = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
        {
            Sprite sprite = backgrounds[i].GetComponent<SpriteRenderer>().sprite;
            float spriteWidth = sprite.bounds.size.x;
            spriteWidths[i] = spriteWidth;
        }
    }

    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            // Mover el fondo a la izquierda usando el parallaxSpeed y parallaxScales[i]
            Vector3 newPosition = backgrounds[i].position;
            newPosition.x -= parallaxSpeed * parallaxScales[i] * Time.deltaTime;
            backgrounds[i].position = newPosition;

            // Si la imagen ha avanzado suficientemente, reposicionarla al inicio
            // Ahora estamos usando 0.5 * spriteWidths[i] que es la mitad de la anchura del sprite.
            // Puedes ajustar esta multiplicación a tu gusto para determinar cuándo se reposiciona.
            if (newPosition.x <= -0.5 * spriteWidths[i])
            {
                Vector3 offsetPosition = newPosition;
                offsetPosition.x += spriteWidths[i];
                backgrounds[i].position = offsetPosition;
            }
        }
    }
}

