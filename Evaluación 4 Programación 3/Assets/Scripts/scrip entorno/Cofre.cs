// Namespace: RPG.Interaction
// Implementa IInteractable. El jugador presiona E para abrirlo
// y recibir un item en su inventario.

using System;
using UnityEngine;
using RPG.Interaction;
using RPG.Inventory;

namespace RPG.Interaction
{
    [RequireComponent(typeof(Collider))]
    public class Cofre : MonoBehaviour, IInteractable
    {
        [SerializeField] private string nombreItem = "Pocion de Vida";
        [SerializeField] private string descripcion = "Restaura 50 de vida.";
        [SerializeField] private int itemId = 20;

        // Evento: notifica cuando el cofre es abierto
        public event Action<string> OnCofreAbierto;

        private bool jugadorEnRango = false;
        private bool yaAbierto = false;

        // Referencia cacheada al inventario del jugador
        private Inventario inventarioJugador;

        private void Awake()
        {
            GetComponent<Collider>().isTrigger = true;
        }

        private void Update()
        {
            if (jugadorEnRango && !yaAbierto && Input.GetKeyDown(KeyCode.E))
                Interactuar(inventarioJugador?.gameObject);
        }

        /// <summary>Abre el cofre y entrega el item al jugador.</summary>
        public void Interactuar(GameObject iniciador)
        {
            if (inventarioJugador == null || yaAbierto) return;

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
                // Cachear inventario una sola vez al entrar al trigger
                inventarioJugador = other.GetComponent<Inventario>();
                jugadorEnRango = true;
                Debug.Log("[Cofre] Presiona [E] para abrir el cofre.");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                jugadorEnRango = false;
                inventarioJugador = null;
            }
        }
    }
}
