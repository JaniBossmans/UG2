using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int level = 1;
    private int score = 0;
    private int lives = 3;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);   
    }
    private void Start()
    {
        NewGame();
    }
    private void NewGame()
    {
        score = 0;
        lives = 3;

        LoadLevel(1);
    }
    private void LoadLevel(int level)
    {
        this.level = level;

        SceneManager.LoadScene("Level" + level);
    }
}
