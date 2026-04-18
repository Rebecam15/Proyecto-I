using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)//Cuando el ckeckpoint colisione con un objeto de tag player
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerRespawn>().CheckPointAlcanzado(transform.position.x,transform.position.y);//Guarda la posición del último checkpoint 
        }
    }
}
