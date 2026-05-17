using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TransicionesPantalla : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    private float duracionFade = 3f;

    private bool fadeIn = false;

    void Start()
    {
        if (fadeIn)
        {
            FadeIn();
        }
        else
        {
            FadeOut();
        }
    }



    public void FadeIn()
    {
        StartCoroutine(FadeCanvas(canvasGroup, canvasGroup.alpha, 0,duracionFade));
    }
    public void FadeOut()
    {
        StartCoroutine(FadeCanvas(canvasGroup, canvasGroup.alpha, 1, duracionFade));
    }


    private IEnumerator FadeCanvas(CanvasGroup canvas, float start, float end, float duration)
    {
        float tiempoPasado = 0.0f;

        while (tiempoPasado < duration)
        {
            tiempoPasado += Time.deltaTime;
            canvas.alpha = Mathf.Lerp(start, end, tiempoPasado / duration);
            yield return null;
        }
        canvas.alpha = end;

    }
}
