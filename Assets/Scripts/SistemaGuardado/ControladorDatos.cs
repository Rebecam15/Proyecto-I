using UnityEngine;
using System.IO;
using Unity.VisualScripting;

public class ControladorDatos : MonoBehaviour
{
    public GameObject player;

    public ProgresoJuego progreso;
   // public static int vidas; //Para comparar con SistemaVidas.vidas

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
                SistemaVidas.vidas = SistemaVidas.GetVidasIniciales(); //Reinicia el número de vidas al chocar con un checkpoint
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
            SistemaVidas.vidas = progreso.vidas;
            LucesManager.zonaActual = progreso.zonaAnterior;//Se cambia a la zona anterior porque, al empezar en un chechpoint, se suma una zona al colisionar con él.
    }

    private void GuardarDatos() //Guarda la posición del jugador en un archivo
    {
        
        progreso.posicion = player.transform.position;
        progreso.vidas = SistemaVidas.vidas;
        progreso.zonaAnterior = LucesManager.zonaAnterior;

        string progresoJson = JsonUtility.ToJson(progreso);
        Debug.Log(progresoJson);
        PlayerPrefs.SetString("Progreso", progresoJson);

        Debug.Log("Guardando posicion " + progresoJson);
    }
}
