using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

    public class SistemaVidas : Singleton<SistemaVidas>
{

    [SerializeField] private static int numeroInicialVidas = 3;
    private static int vidas=3; //Vidas actuales del jugador. Cambiar luego a 3.


    public UIDocument uiDocument;
    private static Label textoVidas;

    public event Action<int> CambioVidas;


    void Start()
    {
        textoVidas = uiDocument.rootVisualElement.Q<Label>("textoVidas");//.rootvisualElement da acceso al nivel más alto del contenedor de UI Layout. La Q busca el primer label con el nombre textoVidas.
                                                                         //textoVidas.text = "Vidas: " + vidas;
        Debug.Log(vidas);
    }

    public static void SetVidas(int _vidas)
    {
        vidas = _vidas;
        //textoVidas.text = "Vidas: " + vidas;
        Debug.Log(vidas);
    }

    public static int GetVidas()
    {
        return vidas;
    }

    public void OnCollisionEnter2D(Collision2D collision) //Cuando colisiona
    {
       
        if (collision.gameObject.CompareTag("Enemigo") && vidas>0) //Si está vivo y choca contra un enemigo
        {
            vidas--;
            // textoVidas.text = "Vidas: " + vidas; //Actualiza el texto de vidas
            Debug.Log(vidas);
            CambioVidas?.Invoke(vidas);


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
        textoVidas.text = "Vidas: " + vidas; //Actualiza el texto de vidas
        CambioVidas?.Invoke(vidas);

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



