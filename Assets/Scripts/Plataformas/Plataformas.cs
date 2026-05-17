/*using UnityEngine;

public class Plataformas : MonoBehaviour
{
    public ConfCangrejo configuracion;
    private Rigidbody2D rb;
    private float cronometro;
    private int direccionActual = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (configuracion != null)
        {
            cronometro = configuracion.tiempoParaCambiar;
        }
    }

    void Update()
    {
        if (configuracion == null) return;

        cronometro -= Time.deltaTime;

        if (cronometro <= 0f)
        {
            CambiarDireccion();
        }
    }

    void FixedUpdate()
    {
        if (configuracion == null) return;

        rb.linearVelocity = new Vector2(direccionActual * configuracion.velocidad, rb.linearVelocity.y);
    }

    void CambiarDireccion()
    {
        direccionActual *= -1;
        cronometro = configuracion.tiempoParaCambiar;

        /* Opcional para girar el sprite visualmente
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala; 
        */
//}
//}

using UnityEngine;

public enum TipoMovimiento { Horizontal, Vertical }

public class Plataformas : MonoBehaviour
{
    public ConfPlataformas configuracion;
    private Rigidbody2D rb;
    private float cronometro;
    [SerializeField] private int direccionActual = 1;
    public TipoMovimiento tipoMovimiento;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (configuracion != null)
        {
            cronometro = configuracion.tiempoParaCambiar;
        }
    }

    void Update()
    {
        if (configuracion == null) return;

        cronometro -= Time.deltaTime;

        if (cronometro <= 0f)
        {
            CambiarDireccion();
        }
    }

    void FixedUpdate()
    {
        if (configuracion == null) return;

        if (configuracion.tipoMovimiento == TipoMovimiento.Horizontal)
        {
            rb.linearVelocity = new Vector2(direccionActual * configuracion.velocidad, rb.linearVelocity.y);
        }
        else if (configuracion.tipoMovimiento == TipoMovimiento.Vertical)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, direccionActual * configuracion.velocidad);
        }
    }

    void CambiarDireccion()
    {
        direccionActual *= -1;
        cronometro = configuracion.tiempoParaCambiar;

        /*if (configuracion.tipoMovimiento == TipoMovimiento.Horizontal)
        {
            /* Opcional para girar el sprite visualmente
            Vector3 escala = transform.localScale;
            escala.x *= -1;
            transform.localScale = escala; 
            
        }*/
    }
}
