using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

/*
 Recibe la cuenta de luces recogidas por el jugador
 */
public class LucesManager : MonoBehaviour
{
    private int tieneLuces;
    private static int necesitaLuces;

    private int lucesTutorial = 1;
    private int lucesNormal = 3;

    [SerializeField] private GameObject limite;
    [SerializeField] private GameObject limiteAnterior;

    private CheckPointManager checkPointManager;

    public void Start()
    {
        checkPointManager = FindFirstObjectByType<CheckPointManager>();

        RecogerLuz recogerLuces = RecogerLuz.Get();//Se crea una variable de tipo RecoegerLuz

        if (recogerLuces != null)
        {
            recogerLuces.LuzRecogida += NumeroLuces;//Suscribirse a RecogerLuces

            NumeroLuces(recogerLuces.GetLuces());
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)//Cuando el ckeckpoint colisione con un objeto de tag player
    {
        if (collision.gameObject.CompareTag("Player"))
        {
                CuantasLucesNecesita();
                Debug.Log("NecesitaLuces " + necesitaLuces);
                limite.SetActive(true);
                limiteAnterior.SetActive(true);
        }
    }

    public void NumeroLuces(int numero)
    {
        Debug.Log("Luz recogida");
        tieneLuces = numero;
        Debug.Log("Luces"+ tieneLuces +"/ "+ necesitaLuces);
        ComprobarLuces();
    }



    public void ComprobarLuces()
    {
        if (tieneLuces < necesitaLuces)
        {
            Debug.Log("No tienes suficientes luces");
            Debug.Log(tieneLuces + "/" + necesitaLuces);
        }
        else
        {
            Debug.Log("Puedes pasar de zona");

            limite.SetActive(false);
        }
    }

    public void CuantasLucesNecesita()
    {
        int indice = checkPointManager.GetIndice();

        Debug.Log("Has entrado en cuantas luces necesita "+ indice);

        if (indice == 0)
        {
            necesitaLuces = lucesTutorial;
        }
        else
        {
            necesitaLuces = lucesNormal;
        }
    }

  

}

