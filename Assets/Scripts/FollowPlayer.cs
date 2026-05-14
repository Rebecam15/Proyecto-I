using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UIElements;

public class FollowPlayer : MonoBehaviour
{
    public Transform _player;

    private int moverCamaraY;
    private int subirCamara = 2;
    private int bajarCamara = -5;

    private float yVelocity = 0.0f;
    private float xVelocity=0.0f;
    private float bajarAcantilados;

    public float smoothTiempo= 0.25f;


    void LateUpdate() //Para suavizar la cámara. Se ejecuta después del movimiento
    {

        if (LucesManager.zonaActual != LucesManager.Zona.Playa)
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
