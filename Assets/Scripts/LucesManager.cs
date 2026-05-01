using UnityEngine;

public class LucesManager : MonoBehaviour
{
    //A medio hacer 
    enum Zona { Tutorial, Pueblo, Playa, Faro };
    Zona zonaActual;

    public GameObject CPTutorial;
    public GameObject CPPueblo;
    public GameObject CPPlaya;
    public GameObject CPFaro;

    private GameObject ultimoCP;

    void Start()
    {
        zonaActual = Zona.Tutorial;
        ultimoCP= CPTutorial;
    }

    public void OnTriggerEnter2D(Collider2D collision)//Cuando el ckeckpoint colisione con un objeto de tag player
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           zonaActual= ReverseDirection(zonaActual);
            Debug.Log(zonaActual);
        }
    }

    Zona ReverseDirection(Zona zona)
    {
        if (zona == Zona.Tutorial)
            zona = Zona.Pueblo;
        else if (zona == Zona.Pueblo)
            zona = Zona.Playa;
        else if (zona == Zona.Playa)
            zona = Zona.Faro;
        else if (zona == Zona.Faro)
            zona = Zona.Tutorial;

        return zona;
    }
}
