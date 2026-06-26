// Segunda implementacion de IInteractable con Interact().
// con su propia logica al ser interactuado.

using System;
using UnityEngine;
using RPG.Inventory;

namespace RPG.Interaction
{
    [RequireComponent(typeof(Collider))]
    public class Cofre : MonoBehaviour, IInteractable
    {
        [Header("Item de recompensa")]
        [SerializeField] private int itemId = 20;
        [SerializeField] private string nombreItem = "Pocion de Vida";
        [SerializeField] private string descripcion = "Restaura 50 de vida.";

        public event Action<string> OnCofreAbierto;
        private bool yaAbierto = false;
        private Inventario inventarioJugador;

        private void Awake()
        {
            GetComponent<Collider>().isTrigger = true;
        }

        public void Interact()
        {
            if (yaAbierto || inventarioJugador == null) return;

            yaAbierto = true;

            Item recompensa = new Item(itemId, nombreItem, descripcion);
            inventarioJugador.AgregarItem(recompensa);

            Debug.Log($"[Cofre] Cofre abierto. Item entregado: {nombreItem}");
            OnCofreAbierto?.Invoke(nombreItem);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                inventarioJugador = other.GetComponent<Inventario>();
                Debug.Log("[Cofre] Presiona [E] para abrir el cofre.");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
                inventarioJugador = null;
        }
    }
}
