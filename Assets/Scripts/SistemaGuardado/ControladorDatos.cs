using UnityEngine;
using System.IO;
using Unity.VisualScripting;

public class ControladorDatos : MonoBehaviour
{
    public GameObject player;
    private Vector2 posInicio = new Vector2(5, -2);
    private Vector2 posCP;

    public ProgresoJuego progreso;
    private bool choqueCheckpoint;
    public static int vidas; //Para comparar con SistemaVidas.vidas

   private bool cargar; //Para cargar o no



    private void Awake() //Al empezar
    {
        progreso = new ProgresoJuego();
        cargar = false;

        if (cargar == true)
        {
            CargarDatos();
        }
        /*else if (cargar == false) //Si no se carga nada, las vidas son igual a 3. Tal vez nada de esto es necesario
        {
            SistemaVidas.vidas = SistemaVidas.numeroInicialVidas;
            vidas = SistemaVidas.vidas;

            LucesManager.zonaActual = LucesManager.Zona.Inicio;
            progreso.ultimoCP = LucesManager.Zona.Inicio;

            player.transform.position = posInicio;
        }*/
    }
    public void Update()
    {
        vidas = SistemaVidas.vidas;   
    }

    public void OnTriggerEnter2D(Collider2D collision)//Cuando el player colisiona con un objeto
    {
        
            if (collision.gameObject.CompareTag("Checkpoint"))//Si es un checkpoint
            {
                vidas = SistemaVidas.numeroInicialVidas; //Reinicia el número de vidas al chocar con un checkpoint
                SistemaVidas.vidas = vidas;
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
            LucesManager.zonaActual = progreso.zonaAnterior;//Se cambia a la zona anterior porque, al empezar en un chechpoint, se suma una zona al colisionar con él.
    }

    private void GuardarDatos() //Guarda la posición del jugador en un archivo
    {
        Debug.Log("Guardando...");

        if(choqueCheckpoint==true)//Solo guarda las posiciones cuando se choca con un checkpoint
        {
            progreso.posicion = player.transform.position;
            choqueCheckpoint = false;
        }

        vidas= SistemaVidas.vidas;
        progreso.vidas = vidas;
        progreso.zonaAnterior = LucesManager.zonaAnterior;

        string progresoJson = JsonUtility.ToJson(progreso); 
        PlayerPrefs.SetString("Progreso", progresoJson); 
    }
}
