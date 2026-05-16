using UnityEngine;
using System.IO;
using Unity.VisualScripting;

public class ControladorDatos : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private int numeroInicialVidas = 3;

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
            //No carga las vidas, o creo que es el texto
                SistemaVidas.SetVidas(numeroInicialVidas);  //Reinicia el número de vidas al chocar con un checkpoint
                GuardarDatos();
            }

    }

    private void CargarDatos() //Carga la última posición guardada  
    {
            if (!PlayerPrefs.HasKey("Progreso")) return; 
            string json = PlayerPrefs.GetString("Progreso"); 
            progreso = JsonUtility.FromJson<ProgresoJuego>(json);

            Debug.Log(json);

            player.transform.position = progreso.posicion;
            //CheckPointManager.cuentaCP=progreso.cuentaCP;
            CheckPointManager.ultimoCP = progreso.ultimoCP;
        //LucesManager.zonaActual = progreso.zonaAnterior;//Se cambia a la zona anterior porque, al empezar en un chechpoint, se suma una zona al colisionar con él.
    }

    private void GuardarDatos() //Guarda la posición del jugador en un archivo
    {
        
        progreso.posicion = player.transform.position;
        //progreso.zonaAnterior = LucesManager.zonaAnterior;
        // progreso.cuentaCP = CheckPointManager.cuentaCP;
        progreso.ultimoCP = CheckPointManager.ultimoCP;

        string progresoJson = JsonUtility.ToJson(progreso);
        PlayerPrefs.SetString("Progreso", progresoJson);

        Debug.Log(progresoJson);

    }
}
