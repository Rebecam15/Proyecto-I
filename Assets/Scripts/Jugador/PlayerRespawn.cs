using Unity.VisualScripting;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private float checkPointPositionX, checkPointPositionY;

    //Hay que hacer un sistema de guardado en el que se llame a Respawn al entrar en el juego 

    public void Respawn() //mueve al jugador a la posición del último checkpoint.
    { 
            transform.position = new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY"));       
    }
    
    public void CheckPointAlcanzado(float x, float y)//Guarda la posición del último checkpoint al que se ha llegado
    {
        PlayerPrefs.SetFloat("checkPointPositionX",x);
        PlayerPrefs.SetFloat("checkPointPositionY", y);      
    }
}
