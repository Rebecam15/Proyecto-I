using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    private float areaInteraccion = 1.0f;

    void Update()
    {
        StartInteraction();
    }

    public void StartInteraction()
    {
        float distanciaMinimaInteraccion = float.MaxValue;
        IInteractable interactableMasCercano = null;

        
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, areaInteraccion); //Detecta colliders en una esfera del radio del areaInteraccion
        foreach (Collider2D c in hitColliders) //Recorre todos los colliders encontrados
        {
            IInteractable interactuable = c.GetComponent<IInteractable>();//Busca componente Iinteractable.
            if (interactuable != null && interactuable.PuedeInteractuar(gameObject)) //Si puede iteractuar
            {
                float distancia = Vector3.Distance(gameObject.transform.position, c.transform.position); //Calcula la distancia entre el jugador y el objeto
                if (distancia < distanciaMinimaInteraccion)//Si puede interactuar (incluye todos los objetos con los que pueda interactuar)
                {
                    distanciaMinimaInteraccion = distancia;//Busca el más cercano
                    interactableMasCercano = interactuable;//Lo guarda en la variable 
                }
            }
        }

        interactableMasCercano?.Interactuar(gameObject);
    }


        
    }
