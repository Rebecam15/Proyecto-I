using Unity.VisualScripting;
using UnityEngine;

public class SistemaVidas : MonoBehaviour
{
    [SerializeField] private int vidas;
    public bool muerto;

    void start()
    {
        vidas = 3;
        muerto = false;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (vidas <= 0)
        {
            muerto = true;
            Debug.Log("El personaje ha muerto");
        }
        if (collision.gameObject.CompareTag("Enemigo") && muerto==false)
        {
            vidas--;
            Debug.Log("El jugador ha chocado contra un enemigo");
        }
    }

}



