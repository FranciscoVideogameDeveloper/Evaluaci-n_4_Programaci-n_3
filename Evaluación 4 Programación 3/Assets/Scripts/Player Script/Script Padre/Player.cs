using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player 
{
    protected string nombre;
    protected float velocidad;
    protected float nivel = 100;
    protected float vida = 100;
    protected int energia = 100;
    protected bool habilidadEspecial;
    protected int magia = 100;

    public abstract void AplicarClase();
}
