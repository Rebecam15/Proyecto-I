using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class RecogerLuz : MonoBehaviour, IInteractable
{
    [SerializeField] private bool _recogido = false;
    public static int luces=0;

    public bool PuedeInteractuar(GameObject objetoInteractuar)
    {
        Debug.Log("Puede interactuar");
        return !_recogido;

    }

    public void Interactuar(GameObject objetoInteractuar)
    {
            luces++;  
            _recogido = true;
            Debug.Log($"Luces es igual a {luces}");
            gameObject.SetActive(false);
    }

}
