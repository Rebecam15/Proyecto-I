using UnityEngine;

public class CheckPointManager : MonoBehaviour
{

    [SerializeField] private GameObject[] checkPoints;

    private int cantidadArray = 5;
   
    public static GameObject ultimoCP;
    public static int cuentaCP=0;

    public void Start()
    {
        checkPoints = new GameObject[cantidadArray];
    }
   /* public void QueCP()
    {
        ultimoCP= checkPoints[cuentaCP];
    }*/
    public void OnTriggerEnter2D(Collider2D collision)//Cuando el ckeckpoint colisione con un objeto de tag player
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            Debug.Log("Zona "+ultimoCP);
            //QueCP();

          if(ultimoCP != collision.gameObject)
            { 
                cuentaCP++;
                ultimoCP = collision.gameObject;
            }

         
        }
    }
}
