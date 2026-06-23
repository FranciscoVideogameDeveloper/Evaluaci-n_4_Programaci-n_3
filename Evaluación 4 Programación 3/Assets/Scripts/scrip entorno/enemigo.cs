// Implementa IDamageable y ataca al jugador cuando esta cerca.
// Presiona F cerca del enemigo para dañarlo.

using System;
using UnityEngine;
using RPG.Interaction;

public class Enemigo : MonoBehaviour, IDamageable
{
    [Header("Vida")]
    [SerializeField] private float vidaMaxima = 100f;

    [Header("Ataque")]
    [SerializeField] private float danio = 10f;
    [SerializeField] private float cooldownAtaque = 1.5f;
    [SerializeField] private float rangoDeteccion = 3f;

    private float vidaActual;
    private float timerAtaque;

    // Referencia cacheada al jugador (se obtiene una sola vez en Start)
    private PlayerController player;

    public event Action<string> OnEnemigoDerrotado;

    private void Start()
    {
        vidaActual = vidaMaxima;
        timerAtaque = 0f;
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (player == null) return;

        float distancia = Vector3.Distance(transform.position, player.transform.position);

        // Si el jugador esta dentro del rango, atacar con cooldown
        if (distancia <= rangoDeteccion)
        {
            timerAtaque -= Time.deltaTime;

            if (timerAtaque <= 0f)
            {
                player.RecibirDanio(danio);
                Debug.Log($"[Enemigo] {gameObject.name} ataco al jugador por {danio}.");
                timerAtaque = cooldownAtaque;
            }
        }
    }

    /// Recibe daño. Si llega a 0 muere y dispara el evento.
    public void RecibirDanio(float cantidad)
    {
        vidaActual -= cantidad;
        Debug.Log($"[Enemigo] {gameObject.name} recibio {cantidad}. Vida: {vidaActual}/{vidaMaxima}");

        if (vidaActual <= 0f)
            Morir();
    }

    private void Morir()
    {
        Debug.Log($"[Enemigo] {gameObject.name} derrotado.");
        OnEnemigoDerrotado?.Invoke(gameObject.name);
        Destroy(gameObject);
    }
}
