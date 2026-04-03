using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] private float speed;//Añadir speed

    private Vector2 movementValue;

    public void OnMove(InputValue value)
    {
        movementValue = value.Get<Vector2>(); //The values of x and y are read and saved in movementValue.
        Debug.Log("Movimiento: " + movementValue);

    }
    void Update()
    {

        //Mover hacia adelante
        Vector2 movimiento = new Vector2(movementValue.x, movementValue.y); //El vector almacena (0,0,1). 20 metros por segundo
        transform.Translate(movimiento * Time.deltaTime * speed);
    }
}