using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] private float speed=10;


    private Vector2 movementValue;

    public void OnMove(InputValue value) //recibe el input y lo guarda en movementValue
    {
        movementValue = value.Get<Vector2>(); 
    }
    void Update() //Actualiza la posición cada frame
    {
    
            Vector2 movimiento = new Vector2(movementValue.x, movementValue.y);
            transform.Translate(movimiento * Time.deltaTime * speed);
                           
    }
}