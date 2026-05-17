using UnityEngine;

//Interfaz para que el jugador interactúe con las estatuas.
public interface IInteractable
{
    bool PuedeInteractuar(GameObject objetoInteractuar);
    void Interactuar(GameObject objetoInteractuar);
}
