using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject camaraAcantilados;
    public GameObject camaraNormal;
    private Vector3 offset= new Vector3(0, 2, -10);
 

    void LateUpdate() //Para suavizar la cámara. Se ejecuta después del movimiento
    {
        if (LucesManager.zonaActual != LucesManager.Zona.Playa)
        {
            transform.position = player.transform.position + offset;
            camaraNormal.SetActive(true);
            camaraAcantilados.SetActive(false);
        }

        else
        {
            Debug.Log("Estas en los acantilados");
            camaraNormal.SetActive(false);
            camaraAcantilados.SetActive(true);
        }      
        
    }

}
