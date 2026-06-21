using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin : Player
{
    public override void AplicarClase()
    {
        vida = 60;
        Debug.Log("Eres un Paladin, tu vida es de: " + vida);
    }
}
