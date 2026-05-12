using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset= new Vector3(0, 2, -10);
    private Vector3 offsetCamara = new Vector3(0, 2, -14);

    void LateUpdate() //Para suavizar la cámara. Se ejecuta después del movimiento
    {
        if (LucesManager.zonaActual != LucesManager.Zona.Playa)
        {
            transform.position = player.transform.position + offset;
        }

        else
        {
            transform.position = player.transform.position + offsetCamara;
        }      
        
    }

}
