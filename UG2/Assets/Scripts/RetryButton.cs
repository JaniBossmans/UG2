using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public void LoadIntroscene()
    {
        SceneManager.LoadScene("IntroScene");
    }
}
