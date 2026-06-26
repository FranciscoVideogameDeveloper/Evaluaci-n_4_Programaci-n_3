// Mueve al jugador. Implementa IDamageable (puede recibir daño).
// Patron de la clase: guarda referencia a IInteractable al entrar
// al trigger y llama Interact() con tecla E.
// Ataca con tecla F usando IDamageable sobre objetos en rango.

using System;
using UnityEngine;
using RPG.Interaction;
using RPG.Inventory;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour, IDamageable
{
    [Header("Movimiento")]
    [SerializeField] private float velocidad = 5f;

    [Header("Ataque — Tecla F")]
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

    // Referencia cacheada a IInteractable — patron de la clase
    // El jugador NO conoce si es cofre, puerta o NPC. Solo conoce la interfaz.
    private IInteractable objetoInteractuable;

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

        // E = interactuar con el objeto en rango (IInteractable)
        if (objetoInteractuable != null && Input.GetKeyDown(KeyCode.E))
            objetoInteractuable.Interact();

        // F = atacar objetos IDamageable en rango
        if (Input.GetKeyDown(KeyCode.F))
            Atacar();
    }

    private void Mover()
    {
        // Gravedad manual — CharacterController no la aplica solo
        velocidadVertical = controller.isGrounded
            ? Vector3.down * 0.5f
            : velocidadVertical + Physics.gravity * Time.deltaTime;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = transform.right * h + transform.forward * v;

        controller.Move((dir * velocidad + velocidadVertical) * Time.deltaTime);

        if (dir.magnitude > 0.1f)
            OnJugadorMovido?.Invoke();
    }

    private void Atacar()
    {
        // Detecta todos los IDamageable en rango con OverlapSphere
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

    // IDamageable — el enemigo llama este metodo para dañar al jugador
    public void RecibirDanio(float cantidad)
    {
        vidaActual = Mathf.Max(0f, vidaActual - cantidad);
        Debug.Log($"[Player] Daño recibido: {cantidad}. Vida: {vidaActual}/{vidaMaxima}");
        OnVidaCambiada?.Invoke(vidaActual, vidaMaxima);

        if (vidaActual <= 0f)
            Debug.Log("[Player] El jugador ha muerto.");
    }

    //  guardar referencia a IInteractable en el trigger
    private void OnTriggerEnter(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null)
        {
            objetoInteractuable = interactable;
            Debug.Log("[Player] Presiona [E] para interactuar.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<IInteractable>() != null)
            objetoInteractuable = null;
    }

    private void AlRecogerItem(Item item)
    {
        Debug.Log($"[Player] Item recogido: {item.nombre}");
    }
}
