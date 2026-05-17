using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    private RecogerLuz luzInstancia;
    private SistemaVidas sVidas;

    [SerializeField] private TMP_Text numeroLuces;
    [SerializeField] private GameObject v1, v2, v3;

    private void Start()
    {
        luzInstancia = GetComponent<RecogerLuz>();
        sVidas = GetComponent<SistemaVidas>();

        luzInstancia.LuzRecogida += OnCambioLuces;
        sVidas.CambioVidas += OnCambioVidas;


        OnCambioLuces(luzInstancia.GetLuces());
        OnCambioVidas(SistemaVidas.GetVidas());

    }


    private void OnCambioLuces(int cuenta)
    {
        numeroLuces.SetText(cuenta.ToString());
    }

    private void OnCambioVidas(int vidas)
    {
        switch (vidas)
        {
            case 0:
                v1.SetActive(false);
                break;
            case 1:
                v1.SetActive(v1.activeSelf);
                break;
            case 2:
                v2.SetActive(v2.activeSelf);
                break;
            case 3:
                v3.SetActive(v3.activeSelf);
                break;
            default:
                break;
        }
    }

    void OnDestroy()
    {
        luzInstancia.LuzRecogida -= OnCambioLuces;
        sVidas.CambioVidas -= OnCambioVidas;
    }
}
