using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int bricksToDestroy;
    private int score = 0;
    private int level = 1;
    private const int NUM_LEVELS = 2;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        InitializeGameComponents();
        NewGame();
    }

    private void InitializeGameComponents()
    {
        bricksToDestroy = 0;
        Brick[] bricksArray = GameObject.FindGameObjectsWithTag("Brick").Select(go => go.GetComponent<Brick>()).ToArray();
        foreach (Brick brick in bricksArray)
        {
            brick.OnBrickDestroyed += HandleBrickDestroyed;
            if (!brick.unbreakable)
            {
                bricksToDestroy++;
            }
        }
    }

    private void NewGame()
    {
        score = 0;
    }

    public void OnBrickHit(Brick brick)
    {
        score += brick.points;
    }

    private void HandleBrickDestroyed()
    {
        bricksToDestroy--;

        if (bricksToDestroy <= 0)
        {
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        level++;

        if (level > NUM_LEVELS)
        {
            LoadLevel(1);
            return;
        }

        SceneManager.LoadScene("Level" + level);
        InitializeGameComponents(); // Reinitialize components for the new level
    }

    private void LoadLevel(int level)
    {
        this.level = level;
        SceneManager.LoadScene("Level" + level);
    }
}
