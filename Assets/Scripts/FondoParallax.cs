using UnityEngine;

public class FondoParallax : MonoBehaviour
{
    private float startPosition;
    private float spriteLenght;
    public GameObject camera;
    [SerializeField] private float parallaxMovement;

    void Start()
    {
        startPosition = transform.position.x;
        spriteLenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }


    void FixedUpdate()
    {
        float distance = camera.transform.position.x * parallaxMovement;
        float movement = camera.transform.position.x * (1 - parallaxMovement);

        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.y);

        if (movement > startPosition + spriteLenght)
        {
            startPosition += spriteLenght;
        }
        else if (movement < startPosition - spriteLenght)
        {
            startPosition -= spriteLenght;
        }

    }
}
