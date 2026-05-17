using UnityEngine;
using System.IO;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;

/*
 Este script guarda y carga datos para que no se reinicien cada vez que se inicie el juego.

 Empieza desde el último checkpoint o desde el inicio dependiendo de si se marca cargar como verdadero o falso.
 Guarda el progreso y devuelve las vidas al máximo cada vez que el jugador choque con un checkpoint.

 */
public class ControladorDatos : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private GameObject ultimo;

    public ProgresoJuego progreso;

    [SerializeField] private bool cargar=false; //Para cargar o no


    private void Awake() //Al empezar
    {
        progreso = new ProgresoJuego();


        if (cargar == true)
        {
            CargarDatos();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)//Cuando el player colisiona con un objeto
    {
        
            if (collision.gameObject.CompareTag("Checkpoint"))//Si es un checkpoint
            {
                SistemaVidas vidas = SistemaVidas.Get();

                SistemaVidas.SetVidas(vidas.GetVidasIniciales());  //Reinicia el número de vidas al chocar con un checkpoint
                GuardarDatos();
            }
    }

    private void CargarDatos() //Carga la última posición guardada  
    {
        RecogerLuz luces = RecogerLuz.Get();
        CheckPointManager ultimoCP = CheckPointManager.Get();

        if (!PlayerPrefs.HasKey("Progreso")) return; 
        string json = PlayerPrefs.GetString("Progreso"); 
        progreso = JsonUtility.FromJson<ProgresoJuego>(json);

        Debug.Log(json);

        player.transform.position = progreso.posicion;
        if (ultimoCP.GetUltimoCP() != null)
        {
           ultimo = ultimoCP.GetUltimoCP();
           ultimo = progreso.ultimoCP;
        }     
        luces.SetLuces(progreso.lucesRecogidas);
    }

    private void GuardarDatos() //Guarda la posición del jugador 
{
        RecogerLuz luces = RecogerLuz.Get();
        CheckPointManager ultimoCP = CheckPointManager.Get();

        progreso.posicion = player.transform.position;
        if (ultimoCP.GetUltimoCP() != null)
        {
            progreso.ultimoCP = ultimoCP.GetUltimoCP();
        }
        progreso.lucesRecogidas = luces.GetLuces();
     
        string progresoJson = JsonUtility.ToJson(progreso);
        PlayerPrefs.SetString("Progreso", progresoJson);

        Debug.Log(progresoJson);
    }
}
