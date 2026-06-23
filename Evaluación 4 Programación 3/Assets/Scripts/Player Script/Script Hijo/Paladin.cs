using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin : Player // La clase paladin hereda caracteristicas de la clase "Player", denominada como clase padre.
{
    public override void AplicarClase() // Se llama al metodo creado en la clase "Player" mediante el metodo "Override" para que este sea capaz de sobreescribir el valor de la variable asignado en un inicio
    {
        vida = 60;
        // Se asigna un nuevo valor a la variable vida

        Debug.Log("Eres un Paladin, tu vida es de: " + vida);
        // La consola lanza un texto como corroboracion de que se ejecuto el metodo correctamente sumado al nuevo valor de la variable,
    }
}
