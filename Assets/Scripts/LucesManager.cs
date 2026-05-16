using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

/*
 Se crea una enumeración Zona que controlará la zona en la que esté el jugador
 Recibe la cuenta de luces recogidas por el jugador
 */
public class LucesManager : MonoBehaviour
{
    public enum Zona { Inicio, Tutorial, Pueblo, Playa, Faro };
    public static Zona zonaActual;
    public Zona zonaAnterior;

    private int tieneLuces;
    private static int necesitaLuces;

    [SerializeField] private GameObject limite;
    [SerializeField] private GameObject limiteAnterior;



    public void Start()
    {
       
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
             if (PlayerRespawn.mismoCP == false)//Si es un nuevo CheckPoint
             {
                 zonaAnterior = zonaActual;
                 zonaActual = PasarZona(zonaActual);
                 
                 Debug.Log(zonaActual);
                 Debug.Log("NecesitaLuces "+ necesitaLuces);

                limite.SetActive(true);
                limiteAnterior.SetActive(true);
             }
           

        }
    }

    public void NumeroLuces(int numero)
    {
        tieneLuces = numero;
        Debug.Log("Luces"+ tieneLuces +"/ "+ necesitaLuces );
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

    Zona PasarZona(Zona zona)
    {
        if (zona == Zona.Inicio)
        {
            zona = Zona.Tutorial;
            necesitaLuces = 1;
        }

        else if (zona == Zona.Tutorial)
        {
            zona = Zona.Pueblo;
            necesitaLuces = 3;

        }

        else if (zona == Zona.Pueblo)
        {
            necesitaLuces = 3;
            zona = Zona.Playa;

        }

        else if (zona == Zona.Playa)
        {
            necesitaLuces = 4;
            zona = Zona.Faro;
        }

        else if (zona == Zona.Faro)
            zona = Zona.Tutorial;

        return zona;
    }

}

