using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class SistemaVidas : MonoBehaviour
{
    [SerializeField] private int numeroInicialVidas = 3;
    public static int vidas; //Vidas actuales del jugador
    public GameObject luz;


    public UIDocument uiDocument;
    private Label textoVidas;

    void Start()
    {
        vidas = numeroInicialVidas;
        textoVidas = uiDocument.rootVisualElement.Q<Label>("textoVidas");//.rootvisualElement da acceso al nivel más alto del contenedor de UI Layout. La Q busca el primer label con el nombre textoVidas.
       
        /* Para cambiarlo por corazones o algo así. Cambiar el laber por una imagen.
         * var image = new Image();
           image.image = Resources.Load<Texture2D>("sample-image");*/
    }

    public static int NumeroVidas() //Develve cuántos checkpoints ha alcanzado
    {
        return vidas;
    }

    public void OnCollisionEnter2D(Collision2D collision) //Cuando colisiona
    {
       
        if (collision.gameObject.CompareTag("Enemigo") && vidas>0) //Si está vivo y choca contra un enemigo
        {
            vidas--;
            textoVidas.text = "Vidas: " + vidas;
           
            if (vidas <1)
            {
                vidas = numeroInicialVidas;
               

                PlayerRespawn respawn = GetComponent<PlayerRespawn>();

                if (respawn != null)
                {
                    respawn.Respawn(); //Mueve al jugador al último checkpoint
                }
                else
                {
                    Debug.LogError("No se encontró PlayerRespawn en este objeto");
                }

                textoVidas.text = "Vidas: " + vidas;
            } 
        }
    }

    

}



