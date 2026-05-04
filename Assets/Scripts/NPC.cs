
using UnityEngine;



public class ConfiguracionNPC : MonoBehaviour
{
    public float velocidad = 3f;

    //Le he puesto 2 segundos entre una dirección y otra pero se puede cambiar sin problema
    public float tiempoParaCambiar = 2f; 

    private Rigidbody2D rb;
    private float cronometro;

    //Le he puesto por defecto que vaya de primeras a la derecha pero se puede cambiar tmb
    private int direccionActual = 1; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cronometro = tiempoParaCambiar;
    }

    void Update()  //Creo que esto está bien pero no estoy segura del todo
    {
        //Esto es para descontar el tiempo como si fuera un cronometro
        cronometro -= Time.deltaTime;

        //Cuando llega a cero, la dirección se cambia
        if (cronometro <= 0f)
        {
            CambiarDireccion();
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direccionActual * velocidad, rb.linearVelocity.y);
    }

    void CambiarDireccion()
    {
        direccionActual *= -1;

        cronometro = tiempoParaCambiar;

        //Esto último lo dejo como comentario porque se supone que es para que el npc también cambia hacia dónde está mirando
        //Lo podemos usar si eso más adelante porque habría que cuadrad animaciones y tal
        //Lo pongo solo como sugerencia, no es necesario para el código
        /*Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;*/
    }
}
