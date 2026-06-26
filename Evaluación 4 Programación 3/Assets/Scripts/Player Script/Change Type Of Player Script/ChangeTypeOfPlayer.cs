using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTypeOfPlayer : MonoBehaviour // A diferencia de los Scripts anteriores, este hereda directamente de "MonoBehaviour" porque no modificara ninguna variable del script de "Player" solo las invocará.
{
    Player claseActual; // Se crea una variable para instanciar un metodo de otro script.

    void Awake() // Se utiliza el metodo "Void Awake" para llamar a los metodos necesarios antes de que el juego inicie para que estos se ejecuten de mojor manera.
    {
        claseActual = new Paladin(); //Crea una neva variable para que el player pueda acceder al codigo de "Paladin" e inicie como esta clase por defecto.
        claseActual.AplicarClase(); //Se hace el llamado del metodo para que este se ejecute con sus variables y sus valores asignados. 

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Alfombra Luchador")) // Se corrobora mediante un "if" que el objeto al que colisionamos, el cual es trigger tenga los debidos tags asignados.
        {
            claseActual = new Luchador(); // Una vez corroborada la informacion, este hace cambio a la clase "Luchador", mediante el mismo metodo utlizado al inicio.
            claseActual.AplicarClase(); // Se hace el llamado al metodo de la clase Player.
        }
        
        if (other.CompareTag("Alfombra Mago")) // Se corrobora mediante un "if" que el objeto al que colisionamos, el cual es trigger tenga los debidos tags asignados.
        {
            claseActual = new Mago(); // Una vez corroborada la informacion, este hace cambio a la clase "Paladin", mediante el mismo metodo utlizado al inicio.
            claseActual.AplicarClase();
        }
    }
}
