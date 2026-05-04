using UnityEngine;

public class NPCEnemigo : MonoBehaviour
{
    public ConfCangrejo configuracion;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float cronometro;
    private int direccionActual = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (configuracion != null)
        {
            cronometro = configuracion.tiempoParaCambiar;

            if (spriteRenderer != null)
            {
                spriteRenderer.color = configuracion.colorNPC;
            }
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

        /* Opcional: Girar el sprite visualmente
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala; 
        */
    }
}