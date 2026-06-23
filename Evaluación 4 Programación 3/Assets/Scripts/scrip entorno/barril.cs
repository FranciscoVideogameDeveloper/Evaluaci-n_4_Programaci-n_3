// Segundo objeto que implementa IDamageable.
// Se destruye al recibir suficiente daño.

using System;
using UnityEngine;
using RPG.Interaction;

public class Barril : MonoBehaviour, IDamageable
{
    [SerializeField] private float resistencia = 30f;
    private float saludActual;

    // Evento: notifica cuando el barril es destruido
    public event Action OnBarrilDestruido;

    private void Start()
    {
        saludActual = resistencia;
    }

    /// <summary>Recibe daño. Se destruye si la salud llega a 0.</summary>
    public void RecibirDanio(float cantidad)
    {
        saludActual -= cantidad;
        Debug.Log($"[Barril] Daño recibido: {cantidad}. Salud restante: {saludActual}");

        if (saludActual <= 0f)
        {
            Debug.Log("[Barril] Barril destruido.");
            OnBarrilDestruido?.Invoke();
            Destroy(gameObject);
        }
    }
}
