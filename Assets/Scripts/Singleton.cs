using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T _instance;
    public static T Get() { return _instance; }

    protected void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = (T)this;
        //DontDestroyOnLoad(gameObject);
    }
}
