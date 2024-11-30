using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance != null) return _instance;

            _instance = FindAnyObjectByType<T>();
            if (_instance != null)
            {
                _instance.gameObject.name = ClassName;
                DontDestroyOnLoad(_instance.gameObject);
                return _instance;
            }

            var singleton = new GameObject { name = ClassName };
            _instance = singleton.AddComponent<T>();
            DontDestroyOnLoad(singleton);
            return _instance;
        }
    }

    private static string ClassName => $"{typeof(T).Name}(Singleton)";
}