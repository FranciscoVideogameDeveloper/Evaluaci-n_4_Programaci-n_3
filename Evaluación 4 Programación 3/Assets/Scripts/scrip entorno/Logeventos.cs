using RPG.Inventory;
using UnityEngine;

public class LogEventos : MonoBehaviour
{
    [SerializeField] private Inventario inventarioJugador;

    private void OnEnable()
    {
        if (inventarioJugador != null)
            inventarioJugador.OnItemAgregado += AlAgregarItem;
    }

    private void OnDisable()
    {
        if (inventarioJugador != null)
            inventarioJugador.OnItemAgregado -= AlAgregarItem;
    }

    private void AlAgregarItem(Item item)
    {
        Debug.Log($"[LogEventos] Nuevo ítem: {item.nombre}");
    }
}