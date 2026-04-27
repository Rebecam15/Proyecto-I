using UnityEngine;
using System.IO;

public class ControladorDatos : MonoBehaviour
{
    public GameObject player;
    public ProgresoJuego progreso;
    private bool choqueCheckpoint = false;
    public static int vidas;

    [SerializeField] private bool cargar;


    private void Awake() //Al empezar
    {
        progreso = new ProgresoJuego();
        

        if (cargar == true)
        {
            CargarDatos();
        }
        else
        {
            SistemaVidas.vidas = 3;
            vidas = SistemaVidas.vidas;
        }
    }

    public void Update()
    {
        vidas = SistemaVidas.vidas;   
    }

    public void OnTriggerEnter2D(Collider2D collision)//Cuando el player colisiona con un Checkpoint
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            choqueCheckpoint = true;
            GuardarDatos();
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
        Debug.Log("Numero Vidas actual" + vidas);

        if(choqueCheckpoint==true)
        {
            progreso.posicion = player.transform.position;
            choqueCheckpoint = false;
        }
        vidas= SistemaVidas.vidas;
        progreso.vidas = vidas;

        string progresoJson = JsonUtility.ToJson(progreso); 
        PlayerPrefs.SetString("Progreso", progresoJson); 
    }
}
