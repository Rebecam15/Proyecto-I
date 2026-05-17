
using Unity.VisualScripting;
using UnityEngine;
using System;
using UnityEngine.Rendering;

public class RecogerLuz : Singleton<RecogerLuz>
{
    private static int luces=0;

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
