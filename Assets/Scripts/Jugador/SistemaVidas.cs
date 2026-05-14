using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class SistemaVidas : MonoBehaviour
{
    [SerializeField] private static int numeroInicialVidas = 3;
    public static int vidas; //Vidas actuales del jugador


    public UIDocument uiDocument;
    private Label textoVidas;


    void Start()
    {
        textoVidas = uiDocument.rootVisualElement.Q<Label>("textoVidas");//.rootvisualElement da acceso al nivel más alto del contenedor de UI Layout. La Q busca el primer label con el nombre textoVidas.
        Debug.Log("VidasInicio" + vidas);
    }

    public void Update()
    {
        textoVidas.text = "Vidas: " + vidas; //Actualiza el texto de vidas
    }

    public static int GetVidasIniciales()
    {
        return numeroInicialVidas;
    }

    public void OnCollisionEnter2D(Collision2D collision) //Cuando colisiona
    {
       
        if (collision.gameObject.CompareTag("Enemigo") && vidas>0) //Si está vivo y choca contra un enemigo
        {
            vidas--;
           
           
            if (vidas <1)
            {
                MuerteJugador();  
            } 
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Agua"))
        {
            Debug.Log("aguaaa");
            MuerteJugador();
        }
    }

    public void MuerteJugador()
    {
        vidas = numeroInicialVidas;

        PlayerRespawn respawn = GetComponent<PlayerRespawn>();

        if (respawn != null)
        {
            respawn.Respawn(); //Mueve al jugador al último checkpoint
        }
        else
        {
            Debug.LogError("No se encontró PlayerRespawn en este objeto");
        }

    }

}



