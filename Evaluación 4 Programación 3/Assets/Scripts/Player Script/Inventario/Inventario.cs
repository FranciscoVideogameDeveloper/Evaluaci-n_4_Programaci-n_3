
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Inventory
{
 
    public class Inventario : MonoBehaviour
    {
   
        private List<Item> items = new List<Item>();

        private Arma armaEquipada;

        public event Action<Item> OnItemAgregado;

   
        public event Action<Arma> OnArmaEquipada;

        public void AgregarItem(Item item)
        {
            items.Add(item);
           // Debug.Log($"[Inventario] Item recogido: {item.ObtenerInfo()} | Total: {items.Count}");

      
            OnItemAgregado?.Invoke(item);
        }

       
        public bool EliminarItem(Item item)
        {
            if (items.Remove(item))
            {
               // Debug.Log($"[Inventario] Item eliminado: {item.nombre}");
                return true;
            }
            //Debug.LogWarning($"[Inventario] Item '{item.nombre}' no encontrado.");
            return false;
        }
        public void EquiparArma(string nombreArma)
        {
            foreach (Item item in items)
            {
      
                if (item is Arma arma && arma.nombre == nombreArma)
                {
  
                    armaEquipada?.Desequipar();

                    armaEquipada = arma;
                    armaEquipada.Equipar();

                    OnArmaEquipada?.Invoke(armaEquipada);
                    return;
                }
            }
            //Debug.LogWarning($"[Inventario] Arma '{nombreArma}' no encontrada en inventario.");
        }

   
        public Arma ObtenerArmaEquipada() => armaEquipada;

  
        public IReadOnlyList<Item> ObtenerItems() => items.AsReadOnly();

        public void MostrarInventario()
        {
            if (items.Count == 0)
            {
                //Debug.Log("[Inventario] El inventario esta vacio.");
                return;
            }
            //Debug.Log($"[Inventario] === Contenido ({items.Count} item(s)) ===");
            //foreach (Item item in items)
                //Debug.Log("  " + item.ObtenerInfo());
        }

        private void OnDisable()
        {
            OnItemAgregado = null;
            OnArmaEquipada = null;
        }
    }
}
