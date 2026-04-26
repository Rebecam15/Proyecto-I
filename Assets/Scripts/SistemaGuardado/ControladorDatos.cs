using UnityEngine;
using System.IO;

public class ControladorDatos : MonoBehaviour
{
    public GameObject player;
    public ProgresoJuego progreso;
    private bool choqueCheckpoint = false;
    int vidas;

    [SerializeField] private bool cargar;


    private void Awake() //Al empezar
    {
        Debug.Log("Funciona!");
        progreso = new ProgresoJuego();
        

        if (cargar == true)
        {
            CargarDatos();
        }
    }

    public void Update()
    {
        vidas=SistemaVidas.NumeroVidas();
        
    }

    public void OnTriggerEnter2D(Collider2D collision)//Cuando el player colisiona con un Checkpoint
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            choqueCheckpoint = true;
            GuardarDatos();
            Debug.Log("Has pasado por un nuevo checkpoint");
        }
    }

    private void OnDestroy() 
    {
        GuardarDatos(); 
    }

    private void CargarDatos() //Carga la última posición guardada  
    {
       
            if (!PlayerPrefs.HasKey("Progreso")) return; 
            string json = PlayerPrefs.GetString("Progreso"); 
            progreso = JsonUtility.FromJson<ProgresoJuego>(json);

            player.transform.position = progreso.posicion;
            vidas = progreso.vidas;


            Debug.Log("Progreso cargado");
    }

    private void GuardarDatos() //Guarda la posición del jugador en un archivo
    {
        Debug.Log("Archivo guardado");

        if(choqueCheckpoint==true)
        {
            progreso.posicion = player.transform.position;
            choqueCheckpoint = false;
        }
        vidas= SistemaVidas.NumeroVidas();
        progreso.vidas = vidas;

        string progresoJson = JsonUtility.ToJson(progreso); 
        PlayerPrefs.SetString("Progreso", progresoJson); 
    }
}
