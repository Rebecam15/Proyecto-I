using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UIElements;

/*
 Hace que la cámara siga al jugador.

 Cuando el jugador llega a la zona de los acantilados, la cámara baja, para que el jugador pueda ver mejor lo que hay debajo de él.
 */
public class FollowPlayer : MonoBehaviour
{
    public Transform _player;

    private int moverCamaraY;
    private int subirCamara = 2;
    private int bajarCamara = -3;

    private float yVelocity = 0.0f;
    private float xVelocity=0.0f;

    private float smoothTiempo= 0.25f;

    private int zona = 3;
    [SerializeField] GameObject checkPoint2;
    private GameObject comparacionCP;

  
    void LateUpdate() //Para suavizar la cámara. Se ejecuta después del movimiento
    {
        CheckPointManager ultimoCP = CheckPointManager.Get();//Debería quitar esto del update
        if (ultimoCP.GetUltimoCP() != null)
        {
            comparacionCP = ultimoCP.GetUltimoCP();
        }

        if (comparacionCP != checkPoint2)
        {
            moverCamaraY = subirCamara;
        }

        else
        {
            moverCamaraY= bajarCamara;
        }

        float movX = Mathf.SmoothDamp(transform.position.x, _player.position.x, ref xVelocity, smoothTiempo);
        float movY = Mathf.SmoothDamp(transform.position.y, _player.position.y + moverCamaraY, ref yVelocity, smoothTiempo);
        transform.position = new Vector3(movX, movY, transform.position.z);
    }

}
//https://docs.unity3d.com/es/current/ScriptReference/Mathf.SmoothDamp.html
//https://gamedevbeginner.com/how-to-follow-the-player-with-a-camera-in-unity-with-or-without-cinemachine/
