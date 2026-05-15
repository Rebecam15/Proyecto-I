using UnityEngine;
using UnityEngine.Rendering;

public class LucesManager : MonoBehaviour
{
    public enum Zona { Inicio,Tutorial, Pueblo, Playa, Faro };
    public static Zona zonaActual;
    public static Zona zonaAnterior;
    private int tieneLuces;
    private static int necesitaLuces;

    [SerializeField] private GameObject limite;



    public void Start()
    {
        limite.SetActive(true);
        RecogerLuz recogerLuces = RecogerLuz.Get();

        if (recogerLuces!=null)
        {
            recogerLuces.LuzRecogida += NumeroLuces;

            NumeroLuces(recogerLuces.GetLuces());
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)//Cuando el ckeckpoint colisione con un objeto de tag player
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            if (PlayerRespawn.mismoCP == false)
            {
                zonaAnterior = zonaActual;
                zonaActual = PasarZona(zonaActual);
                Debug.Log(zonaActual);

                limite.SetActive(true);
            }
          
        }
    }

    public void NumeroLuces(int numero)
    {
        tieneLuces=numero;
        ComprobarLuces();
    }

 

    public void ComprobarLuces()
    {
        if(tieneLuces<necesitaLuces)
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
