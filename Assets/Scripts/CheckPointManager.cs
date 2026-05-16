using System;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{

    [SerializeField] private static GameObject[] checkPoints;
    private int cantidadArray = 5;
    public static GameObject ultimoCP;

    public void Start()
    {
        checkPoints = new GameObject[cantidadArray];
    }
   /* public void QueCP()
    {
        ultimoCP= checkPoints[cuentaCP];
    }*/
    public void OnTriggerEnter2D(Collider2D collision)//Cuando el ckeckpoint colisione con un objeto de tag player
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
           Debug.Log("Zona "+ultimoCP);

          if(ultimoCP != collision.gameObject)
            { 
                ultimoCP = collision.gameObject;
            }
        }
    }

    public int GetIndice() //Siempre debuelve -1. Hay que mirarlo
    {
        int indice = Array.IndexOf(checkPoints, ultimoCP);
        Debug.Log("Zona "+ indice);
        return indice;
    }
}
