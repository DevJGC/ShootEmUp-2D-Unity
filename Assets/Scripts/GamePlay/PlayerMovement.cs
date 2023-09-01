using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f; // velocidad de movimiento

    // Tamaño del jugador/nave para ajustar correctamente los límites
    private float playerWidth;
    private float playerHeight;

    void Start()
    {
        // BoxCollider2D en la nave para determinar su tamaño
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        //  Comprobar que el collider existe
        if (collider != null)
        {
            playerWidth = collider.size.x / 2;  // Dividido por 2 porque queremos la mitad del tamaño (desde el centro)
            playerHeight = collider.size.y / 2; //  Dividido por 2 porque queremos la mitad del tamaño (desde el centro)
        }
    }

    void Update()
    {
        MovePlayer(); // Mover el jugador
    }

    // Mover el jugador
    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal"); // cambiar a RAW para que el movimiento sea más rápido
        float vertical = Input.GetAxis("Vertical"); //  cambiar a RAW para que el movimiento sea más rápido

        Vector3 movement = new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;

        // Calcular la nueva posición
        Vector3 newPos = transform.position + movement;

        // Convertir las esquinas de la pantalla a coordenadas del mundo
        Vector3 lowerLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 upperRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        // Mantener el jugador dentro de los límites, teniendo en cuenta el tamaño del jugador para no cortarlo en el borde
        newPos.x = Mathf.Clamp(newPos.x, lowerLeft.x + playerWidth, upperRight.x - playerWidth);
        newPos.y = Mathf.Clamp(newPos.y, lowerLeft.y + playerHeight, upperRight.y - playerHeight);

        // Asignar la nueva posición
        transform.position = newPos;
    }
}
