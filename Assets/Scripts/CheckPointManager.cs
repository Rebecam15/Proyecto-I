using UnityEngine;

public class CheckPointManager : MonoBehaviour
{

    [SerializeField] private GameObject[] checkPoints;

    public enum Zona { Inicio, Tutorial, Pueblo, Playa, Faro };
    public static Zona zonaActual;
    public static Zona zonaAnterior;

    private GameObject ultimoCP;

    public void Start()
    {
        checkPoints = new GameObject[5];
        ultimoCP = checkPoints[1];
    }
    public void OnTriggerEnter2D(Collider2D collision)//Cuando el ckeckpoint colisione con un objeto de tag player
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            Debug.Log(collision.gameObject);

          if(ultimoCP== collision.gameObject)
            {
                Debug.Log("Es el mismpCP");
            }
          else
            {
                Debug.Log("Es un nuevo CP");
            }

            ultimoCP = collision.gameObject;
        }
    }
}
