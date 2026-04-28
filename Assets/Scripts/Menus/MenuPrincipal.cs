using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{

    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject mainMenu;

    public void Jugar()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Opciones()
    {
        mainMenu.SetActive(settingsMenu.activeSelf);
        settingsMenu.SetActive(!settingsMenu.activeSelf);

    }

    public void Salir()
    {
        Debug.Log("Chao");
        Application.Quit();
    }

}
