using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 5.0f;

    void Update()
    {
        // Captura la entrada del teclado en los ejes Horizontal y Vertical
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");

        // Crea un vector de direcci�n basado en las teclas presionadas
        Vector3 movimiento = new Vector3(movimientoH, 0.0f, movimientoV);

        // Mueve el jugador en la direcci�n calculada multiplicada por la velocidad y el tiempo
        transform.Translate(movimiento * velocidad * Time.deltaTime);
    }
}
