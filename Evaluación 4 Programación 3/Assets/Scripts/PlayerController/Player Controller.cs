// Mueve al jugador, implementa IDamageable y ataca con tecla F.

using System;
using UnityEngine;
using RPG.Interaction;
using RPG.Inventory;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour, IDamageable
{
    [Header("Movimiento")]
    [SerializeField] private float velocidad = 5f;

    [Header("Ataque")]
    [SerializeField] private float danioAtaque = 20f;
    [SerializeField] private float rangoAtaque = 2f;

    [Header("Vida")]
    [SerializeField] private float vidaMaxima = 100f;
    private float vidaActual;

    public event Action<float, float> OnVidaCambiada;
    public event Action OnJugadorMovido;

    private CharacterController controller;
    private Inventario inventario;
    private Vector3 velocidadVertical;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        inventario = GetComponent<Inventario>();
        vidaActual = vidaMaxima;
    }

    private void OnEnable()
    {
        if (inventario != null)
            inventario.OnItemAgregado += AlRecogerItem;
    }

    private void OnDisable()
    {
        if (inventario != null)
            inventario.OnItemAgregado -= AlRecogerItem;
    }

    private void Update()
    {
        Mover();

        if (Input.GetKeyDown(KeyCode.F))
            Atacar();
    }

    private void Mover()
    {
        // CharacterController requiere gravedad manual
        if (controller.isGrounded)
            velocidadVertical = Vector3.down * 0.5f;
        else
            velocidadVertical += Physics.gravity * Time.deltaTime;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movimiento = transform.right * h + transform.forward * v;
        controller.Move((movimiento * velocidad + velocidadVertical) * Time.deltaTime);

        if (movimiento.magnitude > 0.1f)
            OnJugadorMovido?.Invoke();
    }

    private void Atacar()
    {
        // Busca todos los objetos con IDamageable dentro del rango
        Collider[] enRango = Physics.OverlapSphere(transform.position, rangoAtaque);

        foreach (Collider col in enRango)
        {
            if (col.gameObject == gameObject) continue;

            IDamageable objetivo = col.GetComponent<IDamageable>();
            if (objetivo != null)
            {
                objetivo.RecibirDanio(danioAtaque);
                Debug.Log($"[Player] Ataco a {col.gameObject.name} por {danioAtaque}.");
            }
        }
    }

    /// El jugador puede recibir daño (enemigos, cactus, etc.)
    public void RecibirDanio(float cantidad)
    {
        vidaActual = Mathf.Max(0f, vidaActual - cantidad);
        Debug.Log($"[Player] Daño recibido: {cantidad}. Vida: {vidaActual}/{vidaMaxima}");

        OnVidaCambiada?.Invoke(vidaActual, vidaMaxima);

        if (vidaActual <= 0f)
            Debug.Log("[Player] El jugador ha muerto.");
    }

    private void AlRecogerItem(Item item)
    {
        Debug.Log($"[Player] Item recogido: {item.nombre}");
    }
}
