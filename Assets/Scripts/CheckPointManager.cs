using System;
using UnityEngine;

public class CheckPointManager : Singleton<CheckPointManager>
{

    [SerializeField] private  GameObject[] checkPoints;
    public static int cuentaCP=0;

    private int lucesChoque = 0;

    public static GameObject ultimoCP;
    public static GameObject primerCP;

    public event Action<int> NuevoIndice;

    public void Start()
    {
       // ultimoCP = checkPoints[cuentaCP];
    }
    public void OnTriggerEnter2D(Collider2D collision)//Cuando el ckeckpoint colisione con un objeto de tag player
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
           Debug.Log("Zona "+ultimoCP);

          if(ultimoCP != collision.gameObject)
            {
                RecogerLuz luces = RecogerLuz.Get();

                ultimoCP = collision.gameObject;

                cuentaCP = GetIndice();
                Debug.Log("Indice"+cuentaCP);
                NuevoIndice?.Invoke(cuentaCP);

                luces.SetLuces(lucesChoque);
            }
        }
    }

    public int GetIndice() 
    {
       int indice = Array.IndexOf(checkPoints, ultimoCP);
        Debug.Log("Zona " + indice);
        
        return indice;
    }
    public int GetCuenta()
    {
        return cuentaCP;    
    }

}
