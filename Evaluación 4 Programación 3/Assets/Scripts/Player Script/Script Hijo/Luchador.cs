using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luchador : Player
{
    public override void AplicarClase()
    {
        vida = 40;
        Debug.Log("Eres un Luchador, tu vida es de: " + vida);
    }
}
