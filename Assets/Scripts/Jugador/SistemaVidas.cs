using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

/*
 Organiza las vidas.

 Permite que otros scipts cambien y lean las vidas del jugador.
 Cuando el jugador choca contra un enemigo, pierde una vida.
 Cuando el jugador cae al agua, muere.
 Cuando el jugador se queda sin vidas, muere.
 Cuando el jugador muere, se llama a player.Respawn y vuelve a tener el máximo de vidas.
 */
    public class SistemaVidas : Singleton<SistemaVidas>
{

    [SerializeField] private int numeroInicialVidas = 3;
    private static int vidas=3; //Vidas actuales del jugador. Cambiar luego a 3.


    public UIDocument uiDocument;
    private static Label textoVidas;

    public event Action<int> CambioVidas;

    void Start()
    {
        textoVidas = uiDocument.rootVisualElement.Q<Label>("textoVidas");//.rootvisualElement da acceso al nivel más alto del contenedor de UI Layout. La Q busca el primer label con el nombre textoVidas.
                                                                         //textoVidas.text = "Vidas: " + vidas;
        Debug.Log("Vidas "+vidas);
    }

    public static void SetVidas(int _vidas)
    {
        vidas = _vidas;
        //textoVidas.text = "Vidas: " + vidas;
        //Debug.Log(vidas);
    }

    public int GetVidasIniciales()
    {
        return numeroInicialVidas;
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



