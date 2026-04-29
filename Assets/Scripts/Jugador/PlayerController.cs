using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField] private float speedX = 8f; 
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

    public void OnMove(InputValue value)
    {
        Vector2 movementValue = value.Get<Vector2>();
        horizontalInput = movementValue.x;
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            saltoPedido = true;
        }
    }

    void Update()
    {
        enSuelo = Physics2D.Raycast(controlSuelo.position, Vector2.down, distanciaRaycast, capaSuelo);

        if (enSuelo)
        {
            puedeDobleSalto = true;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * speedX, rb.linearVelocity.y);

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
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
    }
}