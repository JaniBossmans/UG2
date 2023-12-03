// SceneManager.cs
using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    private static OptionMenu _instance;

    public static OptionMenu Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("OptionMenu");
                _instance = go.AddComponent<OptionMenu>();
            }
            return _instance;
        }
    }

    public GameObject graphicMenuPrefab;

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(gameObject);
        else
            _instance = this;

        DontDestroyOnLoad(gameObject);
        Initialize();
    }

    private void Initialize()
    {
        // Plaats hier de logica om je Graphic Menu in te stellen
        GameObject graphicMenu = Instantiate(graphicMenuPrefab);
        // Voeg eventueel extra initialisatielogica toe
    }
}
