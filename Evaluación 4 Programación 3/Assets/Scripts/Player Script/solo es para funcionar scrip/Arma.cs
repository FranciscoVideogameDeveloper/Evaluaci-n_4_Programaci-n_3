
using UnityEngine;


[System.Serializable]
public class Arma : Item
{
    public float danio;
    public string tipoArma;     // Espada, Baston, Martillo

  
    private bool estaEquipada;


    public bool EstaEquipada => estaEquipada;

  
    public Arma(int id, string nombre, string descripcion, float danio, string tipoArma)
        : base(id, nombre, descripcion)
    {
        this.danio = danio;
        this.tipoArma = tipoArma;
        this.estaEquipada = false;
    }

 
    public void Equipar()
    {
        estaEquipada = true;
        Debug.Log($"[Arma] '{nombre}' equipada | Danio: {danio} | Tipo: {tipoArma}");
    }

    public void Desequipar()
    {
        estaEquipada = false;
        Debug.Log($"[Arma] '{nombre}' desequipada.");
    }

   
    public override string ObtenerInfo()
    {
        string estado = estaEquipada ? "EQUIPADA" : "En inventario";
        return $"[Arma #{id}] {nombre} | Danio: {danio} | Tipo: {tipoArma} | {estado}";
    }
}
