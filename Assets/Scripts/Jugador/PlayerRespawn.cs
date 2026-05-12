using Unity.VisualScripting;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private float checkPointPositionX, checkPointPositionY;
    private Vector2 posAnterior;
    public static bool mismoCP=false;
    public void Respawn() //mueve al jugador a la posición del último checkpoint.
    {
        transform.position = new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY"));
    }
    
    public void CheckPointAlcanzado(float x, float y)//Guarda la posición del último checkpoint al que se ha llegado
    {
        if (x==posAnterior.x && y==posAnterior.y) //Si es el mismo checkpoint
        {
            mismoCP = true;
        }
        else//Si es un nuevo checkpoint
        {
            Debug.Log("NuevoCP");
            PlayerPrefs.SetFloat("checkPointPositionX", x);
            PlayerPrefs.SetFloat("checkPointPositionY", y);
            mismoCP = false;
            posAnterior = new Vector2(x, y);//Guarda la posición en la variable posAnterior para despúés comparar
        }
        
       
    }
}
