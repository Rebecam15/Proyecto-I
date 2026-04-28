using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour
{

    [SerializeField] GameObject menuPausa;

    public void InteractPause()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            MenuPausado();
        }
    }
    public void MenuPausado()
    {
        menuPausa.SetActive(!menuPausa.activeSelf);
        if (menuPausa.activeSelf==true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }


    public void MenuPrincipal()
    {
        Debug.Log("Menu principal...");
       // SceneManager.LoadScene("MenuPrincipal");
    }


    public void Salir()
    {
        Debug.Log("Saliendo");
        Application.Quit();
    }

}
