
using Unity.VisualScripting;
using UnityEngine;
using System;
using UnityEngine.Rendering;

public class RecogerLuz : Singleton<RecogerLuz>
{
    public static int luces=0;

    public event Action <int> LuzRecogida;

    public int GetLuces()
    {
        return luces;
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
