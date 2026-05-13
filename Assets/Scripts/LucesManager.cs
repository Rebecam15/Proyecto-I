using UnityEngine;

public class LucesManager : MonoBehaviour
{
    public enum Zona { Inicio,Tutorial, Pueblo, Playa, Faro };
    public static Zona zonaActual;
    public static Zona zonaAnterior;
    private int tieneLuces;
    private int necesitaLuces;

    public void OnTriggerEnter2D(Collider2D collision)//Cuando el ckeckpoint colisione con un objeto de tag player
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            if (PlayerRespawn.mismoCP == false)
            {
                zonaAnterior = zonaActual;
                zonaActual = PasarZona(zonaActual);
            }
            Debug.Log(zonaActual);
        }
    }

    Zona PasarZona(Zona zona)
    {
        if (zona == Zona.Inicio)
            zona = Zona.Tutorial;

        else if (zona == Zona.Tutorial)
        {
            zona = Zona.Pueblo;
            necesitaLuces = 3;
        }

        else if (zona == Zona.Pueblo)
        {
            necesitaLuces = 5;
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
