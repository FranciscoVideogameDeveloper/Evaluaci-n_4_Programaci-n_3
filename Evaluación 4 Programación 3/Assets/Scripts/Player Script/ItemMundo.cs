
using UnityEngine;
using RPG.Inventory;   // para usar Inventario, Item y Arma

namespace RPG.Interaction
{

    [RequireComponent(typeof(Collider))]
    public class ItemMundo : MonoBehaviour, IInteractable
    {
      
        [Header("Datos del Item")]
        [SerializeField] private int itemId = 0;
        [SerializeField] private string nombreItem = "Item sin nombre";
        [SerializeField] private string descripcion = "Sin descripcion.";

        [Header("Es un Arma?")]
        [SerializeField] private bool esArma = false;
        [SerializeField] private float danio = 10f;
        [SerializeField] private string tipoArma = "Espada";

        private bool jugadorEnRango = false;

    
        private Inventario inventarioJugador;

        private void Awake()
        {
  
            Collider col = GetComponent<Collider>();
            if (!col.isTrigger)
            {
                col.isTrigger = true;
                Debug.LogWarning($"[ItemMundo] Collider de '{gameObject.name}' convertido a Trigger.");
            }
        }

        private void Update()
        {
            // Solo escuchar tecla E si el jugador esta en rango
     
            if (jugadorEnRango && Input.GetKeyDown(KeyCode.E))
            {
                Interactuar(inventarioJugador?.gameObject);
            }
        }

  
    


        /// Recoge el item: lo crea, lo agrega al inventario y destruye este objeto.
    
        public void Interactuar(GameObject iniciador)
        {
            if (inventarioJugador == null)
            {
                Debug.LogWarning($"[ItemMundo] No se puede recoger '{nombreItem}': inventario no encontrado.");
                return;
            }

  
            Item itemCreado;

            if (esArma)
                itemCreado = new Arma(itemId, nombreItem, descripcion, danio, tipoArma);
            else
                itemCreado = new Item(itemId, nombreItem, descripcion);

            inventarioJugador.AgregarItem(itemCreado);
            Debug.Log($"[ItemMundo] '{nombreItem}' recogido por {iniciador.name}.");

            // Destruir este objeto fisico de la escena
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {

                inventarioJugador = other.GetComponent<Inventario>();
                jugadorEnRango = true;
                Debug.Log($"[ItemMundo] Jugador cerca de '{nombreItem}'. Presiona [E] para recoger.");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                jugadorEnRango = false;
                inventarioJugador = null;   // Liberar referencia al salir
            }
        }
    }
}
