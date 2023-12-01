using UnityEngine;
using UnityEngine.UI;

public class GameOverDisplay : MonoBehaviour
{
    private Text displayText;

    private void Start()
    {
        GameManager gameManager = GameManager.Instance;

        if (gameManager != null)
        {
            int score = gameManager.GetCurrentScore();
            int level = gameManager.GetCurrentLevel();
            int lives = gameManager.GetCurrentLives();

            // Simuleer het tonen van Game Over of Congratulations
            if (level > 2) // Vervang dit door je eigen winvoorwaarde
            {
                ShowCongratulations(score, level, lives);
            }
            else
            {
                ShowGameOver(score, level, lives);
            }
        }
        else
        {
            Debug.LogError("GameManager not found.");
        }
    }

    private void ShowGameOver(int score, int level, int lives)
    {
        Debug.Log("Showing Game Over");

        // Roep de methode aan om het Text-component op te halen
        displayText = GetTextComponent();

        // Controleer of het Text-component niet null is voordat je het gebruikt
        if (displayText != null)
        {
            displayText.text = "Game Over\nScore: " + score + "\nLevel: " + level + "\nLives: 0";
        }
        else
        {
            Debug.LogError("Text component not found.");
        }
    }

    private void ShowCongratulations(int score, int level, int lives)
    {
        Debug.Log("Showing Congratulations");

        // Roep de methode aan om het Text-component op te halen
        displayText = GetTextComponent();

        // Controleer of het Text-component niet null is voordat je het gebruikt
        if (displayText != null)
        {
            displayText.text = "Congratulations, You Won!\nScore: " + score + "\nLevel: " + level + "\nLives: " + lives;
        }
        else
        {
            Debug.LogError("Text component not found.");
        }
    }

    // Een voorbeeld van een methode om het Text-component op te halen
    private Text GetTextComponent()
    {
        // Hier kun je de logica toevoegen om het Text-component op te halen
        // bijvoorbeeld door GetComponent<Text>() op het huidige GameObject of een ander GameObject.

        // Hier is een voorbeeld waarbij wordt aangenomen dat het Text-component zich op hetzelfde GameObject bevindt:
        return GetComponent<Text>();
    }
}
