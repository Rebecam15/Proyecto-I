using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class SistemaVidas : MonoBehaviour
{
    [SerializeField] private int vidas=3;
    public bool muerto= false;
    public UIDocument uiDocument;
    private Label textoVidas;

    void Start()
    {
        textoVidas = uiDocument.rootVisualElement.Q<Label>("textoVidas");//.rootvisualElement da acceso al nivel más alto del contenedor de UI Layout. La Q busca el primer label con el nombre textoVidas.
       
        /* Para cambiarlo por corazones o algo así. Cambiar el laber por una imagen.
         * var image = new Image();
           image.image = Resources.Load<Texture2D>("sample-image");*/
    }

    public void OnCollisionEnter2D(Collision2D collision) //Cuando colisiona
    {
       
        if (collision.gameObject.CompareTag("Enemigo") && muerto==false) //Si está vivo y choca contra un enemigo
        {
            vidas--;
            textoVidas.text = "Vidas: " + vidas;
            Debug.Log("El jugador ha chocado contra un enemigo");
            if (vidas < 1)
            {
                muerto = true;
                Debug.Log("El personaje está muerto");
            }
        }
    }

    

}



