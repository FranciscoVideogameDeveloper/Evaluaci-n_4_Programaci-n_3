// Escucha eventos del juego y los registra en consola.
// Demuestra desacoplamiento: este script no necesita
// referenciar directamente a PlayerController ni a Inventario.

using UnityEngine;
using RPG.Inventory;

public class LogEventos : MonoBehaviour
{
    // Referencias cacheadas en Awake
    private PlayerController player;
    private Inventario inventario;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        inventario = FindObjectOfType<Inventario>();
    }

    private void OnEnable()
    {
        if (player != null) player.OnVidaCambiada += MostrarVida;
        if (player != null) player.OnJugadorMovido += MostrarMovimiento;
        if (inventario != null) inventario.OnItemAgregado += MostrarItem;
    }

    private void OnDisable()
    {
        // Siempre desuscribir en OnDisable
        if (player != null) player.OnVidaCambiada -= MostrarVida;
        if (player != null) player.OnJugadorMovido -= MostrarMovimiento;
        if (inventario != null) inventario.OnItemAgregado -= MostrarItem;
    }

    private void MostrarVida(float actual, float maxima)
    {
        Debug.Log($"[UI] Vida del jugador: {actual}/{maxima}");
    }

    private void MostrarMovimiento()
    {
        Debug.Log("[UI] Jugador en movimiento (animacion debug).");
    }

    private void MostrarItem(Item item)
    {
        Debug.Log($"[UI] Nuevo item en inventario: {item.nombre}");
    }
}
