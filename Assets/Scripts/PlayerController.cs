using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] private float speed=10;

    private Vector2 movementValue;

    public void OnMove(InputValue value)
    {
        movementValue = value.Get<Vector2>(); 
        Debug.Log("Movimiento: " + movementValue);

    }
    void Update()
    {
        Vector2 movimiento = new Vector2(movementValue.x, movementValue.y); 
        transform.Translate(movimiento * Time.deltaTime * speed);
    }
}