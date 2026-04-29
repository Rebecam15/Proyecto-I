using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField] private float speedX = 8f; // Velocidad al caminar
    private float horizontalInput;

    [SerializeField] private float fuerzaSalto = 12f;
    [SerializeField] private LayerMask capaSuelo;
    [SerializeField] private Transform controlSuelo;
    [SerializeField] private float distanciaRaycast = 0.2f;

    private bool enSuelo;
    private bool puedeDobleSalto;
    private bool saltoPedido;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // OnMove se activa cuando pulsas A/D o Flechas (Configurado en Input Actions)
    public void OnMove(InputValue value)
    {
        // Solo guardamos la X, porque en plataformas la Y la lleva la gravedad
        Vector2 movementValue = value.Get<Vector2>();
        horizontalInput = movementValue.x;
    }

    // OnJump se activa cuando pulsas Espacio
    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            saltoPedido = true;
        }
    }

    void Update()
    {
        // Detectamos si toca el suelo
        enSuelo = Physics2D.Raycast(controlSuelo.position, Vector2.down, distanciaRaycast, capaSuelo);

        if (enSuelo)
        {
            puedeDobleSalto = true;
        }
    }

    private void FixedUpdate()
    {
        // MOVIMIENTO HORIZONTAL:
        // Mantenemos la velocidad actual de Y (gravedad) y cambiamos solo la X
        rb.linearVelocity = new Vector2(horizontalInput * speedX, rb.linearVelocity.y);

        // LÓGICA DE SALTO:
        if (saltoPedido)
        {
            ProcesarSalto();
            saltoPedido = false;
        }
    }

    private void ProcesarSalto()
    {
        if (enSuelo)
        {
            EjecutarSalto();
        }
        else if (puedeDobleSalto)
        {
            EjecutarSalto();
            puedeDobleSalto = false;
        }
    }

    private void EjecutarSalto()
    {
        // Reseteamos la velocidad vertical para que el salto siempre sea igual de potente
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
    }
}