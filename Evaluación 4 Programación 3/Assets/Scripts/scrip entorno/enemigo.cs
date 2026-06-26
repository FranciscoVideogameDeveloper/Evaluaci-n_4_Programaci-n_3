// Implementa IDamageable: recibe daño del jugador (tecla F).
// Detecta al jugador por distancia y le quita vida con cooldown.

using System;
using UnityEngine;
using RPG.Interaction;

public class Enemigo : MonoBehaviour, IDamageable
{
    [Header("Vida")]
    [SerializeField] private float vidaMaxima = 100f;

    [Header("Ataque al jugador")]
    [SerializeField] private float danio = 10f;
    [SerializeField] private float cooldown = 1.5f;
    [SerializeField] private float rangoDeteccion = 3f;

    private float vidaActual;
    private float timerAtaque;
    private PlayerController player;   // cacheado en Start

    public event Action<string> OnEnemigoDerrotado;
    public delegate void DamageHeadler(float remeaningHealth);
    
    public event DamageHeadler Ondamaged;

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

        if (distancia <= rangoDeteccion)
        {
            timerAtaque -= Time.deltaTime;
            if (timerAtaque <= 0f)
            {
                // Llama a IDamageable del jugador — no depende de PlayerController directamente
                IDamageable objetivo = player.GetComponent<IDamageable>();
                objetivo?.RecibirDanio(danio);
                Debug.Log($"[Enemigo] {gameObject.name} ataco al jugador por {danio}.");
                timerAtaque = cooldown;
            }
        }
    }

    

    // IDamageable — el jugador lo daña con tecla F
    public void RecibirDanio(float cantidad)
    {
        vidaActual -= cantidad;
        Debug.Log($"[Enemigo] {gameObject.name} recibio {cantidad}. Vida: {vidaActual}/{vidaMaxima}");
        Ondamaged?.Invoke(vidaActual);
        if (vidaActual <= 0f)
        {
            Morir();
        }

    }

    private void Morir()
    {
        Debug.Log($"[Enemigo] {gameObject.name} derrotado.");
        OnEnemigoDerrotado?.Invoke(gameObject.name);
        Destroy(gameObject);
    }
}
