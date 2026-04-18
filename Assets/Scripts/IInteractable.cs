using UnityEngine;

public interface IInteractable
{
    bool PuedeInteractuar(GameObject objetoInteractuar);
    void Interactuar(GameObject objetoInteractuar);
}
