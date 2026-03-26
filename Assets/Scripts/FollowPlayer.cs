using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset= new Vector3(0, 2, -10);

    void LateUpdate() //Para suavizar la cámara. Se ejecuta después del movimiento
    {
        transform.position = player.transform.position + offset;
    }
}
