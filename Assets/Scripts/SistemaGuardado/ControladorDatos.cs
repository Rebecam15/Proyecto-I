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
            RecogerLuz luces = RecogerLuz.Get();

        if (!PlayerPrefs.HasKey("Progreso")) return; 
            string json = PlayerPrefs.GetString("Progreso"); 
            progreso = JsonUtility.FromJson<ProgresoJuego>(json);

            Debug.Log(json);

            player.transform.position = progreso.posicion;
            CheckPointManager.ultimoCP = progreso.ultimoCP;
            luces.SetLuces(progreso.lucesRecogidas);

    }

    private void GuardarDatos() //Guarda la posición del jugador en un archivo
{
        RecogerLuz luces = RecogerLuz.Get();

        progreso.posicion = player.transform.position;//Quizas quitar
        progreso.ultimoCP = CheckPointManager.ultimoCP;
        progreso.lucesRecogidas = luces.GetLuces();
     

        string progresoJson = JsonUtility.ToJson(progreso);
        PlayerPrefs.SetString("Progreso", progresoJson);

        Debug.Log(progresoJson);

    }
}
