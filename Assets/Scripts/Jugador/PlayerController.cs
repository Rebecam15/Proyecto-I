/*using UnityEngine;

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

}*/




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
    [SerializeField] private float fuerzaPegado = 10f;

    private bool enSuelo;
    private bool puedeDobleSalto;
    private bool saltoPedido;


    private bool mirandoDerecha = true;
    

    //animaciones ---------------
    private Animator miAnimador;
    //---------------------------

    private bool bloqueadoEnSuelo;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //animaciones -------------------------
        miAnimador = GetComponent<Animator>();
        //-------------------------------------
    }

    public void OnMove(InputValue value)
    {
        horizontalInput = value.Get<Vector2>().x;
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            saltoPedido = true;
            bloqueadoEnSuelo = false;
        }
    }

    void Update()
    {
        enSuelo = Physics2D.Raycast(controlSuelo.position, Vector2.down, distanciaRaycast, capaSuelo);

        if (enSuelo)
        {
            puedeDobleSalto = true;
            if (!saltoPedido)
            {
                bloqueadoEnSuelo = true;
            }
        }
        else
        {
            bloqueadoEnSuelo = false;
        }


        Girar();


        //animaciones -------------------------
        float movH = UnityEngine.InputSystem.Keyboard.current.dKey.isPressed ? 1 :
            (UnityEngine.InputSystem.Keyboard.current.aKey.isPressed ? -1 : 0); ;

        miAnimador.SetFloat("Speed", Mathf.Abs(movH));
        //-------------------------------------
    }


    private void Girar()
    {
        if (horizontalInput > 0 && !mirandoDerecha || horizontalInput < 0 && mirandoDerecha)
        {
            mirandoDerecha = !mirandoDerecha;

            Vector3 escalaLocal = transform.localScale;
            escalaLocal.x *= -1;
            transform.localScale = escalaLocal;
        }
    }

    private void FixedUpdate()
    {
        float yVel = rb.linearVelocity.y;

        if (bloqueadoEnSuelo && !saltoPedido && rb.linearVelocity.y <= 0.1f)
        {
            yVel = -fuerzaPegado;
        }

        rb.linearVelocity = new Vector2(horizontalInput * speedX, yVel);

        if (saltoPedido)
        {
            ProcesarSalto();
            saltoPedido = false;
        }
    }

    private void ProcesarSalto()
    {
        if (enSuelo || puedeDobleSalto)
        {
            if (!enSuelo)
            {
                puedeDobleSalto = false;
            }

            bloqueadoEnSuelo = false;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }
}

