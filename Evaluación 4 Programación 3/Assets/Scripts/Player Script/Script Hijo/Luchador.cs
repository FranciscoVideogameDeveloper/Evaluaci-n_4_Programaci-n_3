using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luchador : Player // La clase luchador heredará comportamientos de la clase "Player", denominada anteriormente como "Clase padre"
{
    public override void AplicarClase() // Se llama al metodo creado en la clase "Player" mediante metodo de "Override" para que este script pueda modificar los valores que tiene cada variable
    {
        vida = 40;
        // Se asigna el nuevo valor de vida que sera adoptado por esta clase

        Debug.Log("Eres un Luchador, tu vida es de: " + vida);
        // La consola muestra el resultado mediante un texto sumado al valor actual de la variable.
    }
}
