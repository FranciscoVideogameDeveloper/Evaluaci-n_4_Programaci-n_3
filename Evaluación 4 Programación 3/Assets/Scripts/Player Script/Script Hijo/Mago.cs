using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mago : Player // La clase Mago heredará comportamientos de la clase "Player", anteriormente denominada como clase padre.
{
    public override void AplicarClase() // Se hace el llamado de el metodo creado en la clase "Player" mediante el metodo "Override" para que este sea capaz de sobre escribir datos de una variable ya asignados.
    {
        vida = 80;
        // Se asigna el nuevo valor de variable que adoptara esta clase.

        Debug.Log("Eres un Mago, tu vida es de: " + vida);
        // La consola lanza un texto sumado al valoor actual de la variable para corroborar la información.
    }
}
