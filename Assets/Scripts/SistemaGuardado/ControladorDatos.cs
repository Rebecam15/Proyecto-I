using UnityEngine;
using System.IO;

public class ControladorDatos : MonoBehaviour
{
    public GameObject player;
    public string ArchivoGuardado;
    public DatosGuardado datos= new DatosGuardado();

    [SerializeField] private bool cargar;

    private int ComparadorCheckPoints = 1;

    private void Awake() //Al empezar
    {
        ArchivoGuardado = Application.dataPath + "/datosuego.json";
        player= GameObject.FindGameObjectWithTag("Player");
        CargarDatos();  
    }

    private void Update()
    {
       if(CheckPoint.CheckPointsAlcanzados==ComparadorCheckPoints) //Cada vez que el jugador alcanza un Checkpoint
        {
            GuardarDatos();
            ComparadorCheckPoints++;     
        }
     
    }

    private void CargarDatos() //Carga la última posición guardada  
    {
        if (cargar == true)
        {
            if (File.Exists(ArchivoGuardado))
            {
                string contenido = File.ReadAllText(ArchivoGuardado);
                datos = JsonUtility.FromJson<DatosGuardado>(contenido);

                Debug.Log("Posicion jugador" + datos.posicion);
                player.transform.position = datos.posicion;
            }
            else
            {
                Debug.Log("El archivo no existe");
            }
        }
    }

    private void GuardarDatos() //Guarda la posición del jugador en un archivo
    {
        DatosGuardado nuevosDatos = new DatosGuardado()
        {
            posicion = player.transform.position
        };

        string cadenaJSON= JsonUtility.ToJson(nuevosDatos);
        File.WriteAllText(ArchivoGuardado, cadenaJSON);

        Debug.Log("Archivo guardado");

    }
}
