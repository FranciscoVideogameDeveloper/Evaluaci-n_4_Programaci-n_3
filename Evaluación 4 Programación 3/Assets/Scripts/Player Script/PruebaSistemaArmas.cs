
using UnityEngine;
using RPG.Inventory; 


public class PruebaSistemaArmas : MonoBehaviour
{

    private Inventario inventario;

    private void Awake()
    {

        inventario = GetComponent<Inventario>();

        if (inventario == null)
            Debug.LogError("[PruebaSistemaArmas] No se encontro componente Inventario en este GameObject.");
    }

    private void OnEnable()
    {

        if (inventario != null)
        {
            inventario.OnItemAgregado += AlRecibirItem;
            inventario.OnArmaEquipada += AlEquiparArma;
        }
    }

    private void OnDisable()
    {

        if (inventario != null)
        {
            inventario.OnItemAgregado -= AlRecibirItem;
            inventario.OnArmaEquipada -= AlEquiparArma;
        }
    }

    private void Start()
    {
        DemostrarSistema();
    }


    private void DemostrarSistema()
    {
        if (inventario == null) return;

        Debug.Log("=== INICIO DEMOSTRACION SISTEMA ARMAS ===");


        Item pocion = new Item(10, "Pocion de Vida", "Restaura 50 puntos de vida.");
        Arma espada = new Arma(1, "Espada de Hierro", "Arma basica del Luchador.", 15f, "Espada");
        Arma baston = new Arma(2, "Baston Magico", "Canaliza energia arcana.", 25f, "Baston");
        Arma martillo = new Arma(3, "Martillo Sagrado", "Arma bendecida del Paladin.", 20f, "Martillo");


        inventario.AgregarItem(pocion);
        inventario.AgregarItem(espada);
        inventario.AgregarItem(baston);
        inventario.AgregarItem(martillo);

        // Mostrar inventario completo
        inventario.MostrarInventario();

        // Equipar arma del Luchador — dispara OnArmaEquipada
        inventario.EquiparArma("Espada de Hierro");

        // Simular cambio de clase a Mago
        Debug.Log("[Prueba] Cambiando a clase Mago...");
        inventario.EquiparArma("Baston Magico");

        // Intentar arma inexistente — debe mostrar advertencia
        inventario.EquiparArma("Lanza Fantasma");

        Debug.Log("=== FIN DEMOSTRACION ===");
    }


    private void AlRecibirItem(Item item)
    {
        Debug.Log($"[Evento] Nuevo item en inventario -> {item.nombre}");
    }


    private void AlEquiparArma(Arma arma)
    {
        Debug.Log($"[Evento] Arma equipada -> {arma.nombre} (Danio: {arma.danio})");
    }
}