using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    private int level = 1;
    private int score = 0;
    private int lives = 3;

    private void Awake()
    {
        // Zorg ervoor dat er slechts één instantie van GameManager is
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        score = 0;
        lives = 3;

        
    }


    public void ToLevel2Scene()
    {
        SceneManager.LoadScene("Level2");
    }

    

    public void ToScoreScene()
    {
        SceneManager.LoadScene("ScoreScene");
    }

    
}
