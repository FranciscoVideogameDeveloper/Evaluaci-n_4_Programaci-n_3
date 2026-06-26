// Implementa IInteractable con Interact() 
// El jugador llama objetoInteractuable.Interact() sin saber si es un item, cofre, puerta, etc.

using UnityEngine;
using RPG.Inventory;

namespace RPG.Interaction
{
    [RequireComponent(typeof(Collider))]
    public class ItemMundo : MonoBehaviour, IInteractable
    {
        [Header("Datos del Item")]
        [SerializeField] private int itemId = 0;
        [SerializeField] private string nombreItem = "Item";
        [SerializeField] private string descripcion = "Sin descripcion.";

        [Header("Es Arma?")]
        [SerializeField] private bool esArma = false;
        [SerializeField] private float danio = 10f;
        [SerializeField] private string tipoArma = "Espada";

        // Referencia al inventario del jugador — cacheada en OnTriggerEnter
        private Inventario inventarioJugador;

        private void Awake()
        {
            GetComponent<Collider>().isTrigger = true;
        }

        // IInteractable — el jugador llama Interact() sin parametros
        public void Interact()
        {
            if (inventarioJugador == null)
            {
                Debug.LogWarning("[ItemMundo] No hay inventario en rango.");
                return;
            }

            Item itemCreado = esArma
                ? new Arma(itemId, nombreItem, descripcion, danio, tipoArma)
                : new Item(itemId, nombreItem, descripcion);

            inventarioJugador.AgregarItem(itemCreado);
            Debug.Log($"[ItemMundo] '{nombreItem}' recogido.");
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                inventarioJugador = other.GetComponent<Inventario>();
                Debug.Log($"[ItemMundo] Presiona [E] para recoger '{nombreItem}'.");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
                inventarioJugador = null;
        }
    }
}
