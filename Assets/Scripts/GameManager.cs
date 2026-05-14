using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private static bool inicio;
    public void Awake()
    {
        inicio= true;   
    }
    void Start()
    {
       inicio = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static bool EsInicio()
    {
        return true;
    }
}
