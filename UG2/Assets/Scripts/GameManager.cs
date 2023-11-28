using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private const int NUM_LEVELS = 2;

    private int level = 1;
    private int score = 0;
    private int lives = 3;

    private Ball ball;
    private Paddle paddle;
    private Brick[] bricks;

    private void Awake()
    {
        // Zorg ervoor dat er slechts één instantie van GameManager is
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
        {
            Instance = this;
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

    public void OnBrickHit(Brick brick)
    {
        score += brick.points;

        if (Cleared())
        {
            LoadLevel(level + 1);
        }
    }

    private bool Cleared()
    {
        for (int i = 0; i < bricks.Length; i++)
        {
            if (bricks[i].gameObject.activeInHierarchy && !bricks[i].unbreakable)
            {
                return false;
            }
        }

        return true;
    }

    private void LoadLevel(int level)
    {
        this.level = level;

        if (level > NUM_LEVELS)
        {
            // Start over again at level 1 once you have beaten all the levels
            // You can also load a "Win" scene instead
            LoadLevel(1);
            return;
        }

        SceneManager.LoadScene("Level" + level);
    }

}
