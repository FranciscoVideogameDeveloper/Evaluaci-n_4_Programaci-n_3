// Segundo objeto que implementa IDamageable (distinto al Enemigo).
// con Debugs distintos al recibir daño.

using System;
using UnityEngine;
using RPG.Interaction;

public class Barril : MonoBehaviour, IDamageable
{
    [SerializeField] private float resistencia = 30f;
    private float saludActual;

    public event Action OnBarrilDestruido;

    private void Start()
    {
        saludActual = resistencia;
    }

    // IDamageable — Debug distinto al del Enemigo 
    public void RecibirDanio(float cantidad)
    {
        saludActual -= cantidad;
        Debug.Log($"[Barril] Impacto recibido: {cantidad}. Integridad: {saludActual}/{resistencia}");

        if (saludActual <= 0f)
        {
            Debug.Log("[Barril] El barril ha sido destruido.");
            OnBarrilDestruido?.Invoke();
            Destroy(gameObject);
        }
    }
}
