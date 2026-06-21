using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTypeOfPlayer : MonoBehaviour 
{
    Player claseActual;

    void Awake()
    {
        claseActual = new Paladin();
        claseActual.AplicarClase();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Alfombra Luchador"))
        {
            claseActual = new Luchador();
            claseActual.AplicarClase();
        }

        if (other.gameObject.CompareTag("Alfombra Paladin"))
        {
            claseActual = new Paladin();
            claseActual.AplicarClase();
        }

       
    }
}
