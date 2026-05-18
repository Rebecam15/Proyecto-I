using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

/*
 * Maneja las luces que tiene y que necesita el jugador en cada momento y le permite pasar al siguiente checkpoint o no dependiendo de esto.
 
 Se suscribe a RecogerLuces para recibir la cuenta de luces recogidas por el jugador.
 También se suscribe a CheckPointManager para saber el índice del último checkpoint por el que ha pasado y, por lo tanto, la zona en la que está.
 Activa y desactiva límites dependiendo de la zona en la que esté y de si cumple las condiciones para seguir adelante.
 Define uántas luces necesita hay que recoger dependiendo de la zona en la que esté el jugador.
 */
public class LucesManager : MonoBehaviour
{
    private int tieneLuces;
    private int necesitaLuces;

    private int lucesTutorial = 1;
    private int lucesNormal = 3;

    [SerializeField] private GameObject limite;
    [SerializeField] private GameObject limiteAnterior;

    private CheckPointManager checkPointManager;

    public void Start()
    {
       // checkPointManager = FindFirstObjectByType<CheckPointManager>();

        RecogerLuz recogerLuces = RecogerLuz.Get();//Se crea una variable de tipo RecoegerLuz
        CheckPointManager cpManager= CheckPointManager.Get();   

        if (recogerLuces != null)
        {
            recogerLuces.LuzRecogida += NumeroLuces;//Suscribirse a RecogerLuces

            NumeroLuces(recogerLuces.GetLuces());
        }
        if(cpManager != null)
        {
            cpManager.NuevoIndice += CuantasLucesNecesita;
            CuantasLucesNecesita(cpManager.GetCuenta());
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)//Cuando el ckeckpoint colisione con un objeto de tag player
    {
        if (collision.gameObject.CompareTag("Player"))
        {
                Debug.Log("NecesitaLuces " + necesitaLuces);
                limite.SetActive(true);
                limiteAnterior.SetActive(true);
        }
    }

    public void NumeroLuces(int numero)
    {
        tieneLuces = numero;
        Debug.Log("Luces"+ tieneLuces +"/ "+ necesitaLuces);
        ComprobarLuces();
    }

    public void ComprobarLuces()
    {
        if (tieneLuces >= necesitaLuces)
        {
            limite.SetActive(false);
            Debug.Log("Puedes pasar de zona");
        }
    }

    public void CuantasLucesNecesita(int cuenta)
    {

        Debug.Log("Has entrado en la zona "+ cuenta);

        if(cuenta==0)
        {
            necesitaLuces = lucesTutorial;
        }
        else
        {
            necesitaLuces = lucesNormal;
        }
    }

  

}

