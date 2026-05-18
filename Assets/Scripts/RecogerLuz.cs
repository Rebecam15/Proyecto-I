
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.UI;

/*
 * Lleva la cuenta de las luces que ha recogido el jugador.
 * Mediante un evento, informa de la nueva cantidad de luces a otros scripts.
 * Esta cantidad pede ser modificada desde otros scripts.
 * Desactiva las luces cuando el jugador choca con ellas.
 */
public class RecogerLuz : Singleton<RecogerLuz>
{
    private static int luces=0;
   //[SerializeField] private GameObject[] totalLuces;


    public event Action <int> LuzRecogida;
    public int GetLuces()
    {
        return luces;
    }

    public void SetLuces(int cantLuces)
    {
        luces = cantLuces;
     
    }


    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Luz"))
        {
            luces++;
            other.gameObject.SetActive(false);

            LuzRecogida?.Invoke(luces);
        }
    }

  
}
