using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    
    public static int CheckPointsAlcanzados=0;
    public void OnTriggerEnter2D(Collider2D collision)//Cuando el ckeckpoint colisione con un objeto de tag player
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerRespawn respawn = collision.GetComponent<PlayerRespawn>();
            Debug.Log("Checkpoints alcanzados"+ CheckPointsAlcanzados);
          

            if (respawn != null) //Guarda la posición del último checkpoint 
            {
                respawn.CheckPointAlcanzado(transform.position.x, transform.position.y);
                CheckPointsAlcanzados++;
            }
            CheckPointsAlcanzados++;
        }
    }

}
