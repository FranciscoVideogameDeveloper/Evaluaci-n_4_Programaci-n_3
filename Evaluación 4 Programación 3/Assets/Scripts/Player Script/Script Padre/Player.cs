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

    // Se declaran variables de manera "Protected" para que otros scripts puedan acceder a dicha variable y modificarla.

    public abstract void AplicarClase();

    // Se crea metodo para que sea posible el modificar esta clase por otras clases mediante el llamado de este metodo.

}
