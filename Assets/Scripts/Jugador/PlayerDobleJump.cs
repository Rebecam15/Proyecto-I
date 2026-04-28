using UnityEngine;
using UnityEngine.InputSystem;

public class DobleJump : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float fuerzaSalto;
    [SerializeField] private LayerMask suelo;
    [SerializeField] private Transform controlSuelo;
    [SerializeField] private float distanciaRaycast = 0.2f;

    private bool enSuelo;
    private bool puedeDobleSalto;
    private bool saltoPedido;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        enSuelo = Physics2D.Raycast(controlSuelo.position, Vector2.down, distanciaRaycast, suelo);

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            saltoPedido = true;
        }
    }

    private void FixedUpdate()
    {
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
            puedeDobleSalto = true;
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

        rb.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
    }
}
