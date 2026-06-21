using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mago : Player
{
    public override void AplicarClase()
    {
        vida = 80;
        Debug.Log("Eres un Mago, tu vida es de: " + vida);
    }
}
