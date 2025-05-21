using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;

    public GameObject gameOverUI;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;

    private void Awake()
    {
        instance = this;
    }

    public void ShowGameOver(int finalScore)
    {
        // Update score text
        scoreText.text = "Score: " + finalScore;

        // Save & display best score
        int best = PlayerPrefs.GetInt("BestScore", 0);
        if (finalScore > best)
        {
            PlayerPrefs.SetInt("BestScore", finalScore);
        }
        bestScoreText.text = "Best: " + PlayerPrefs.GetInt("BestScore");

        // Show UI
        gameOverUI.SetActive(true);

        // Optional: pause game
        Time.timeScale = 0f;
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game clicked!");
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
}

}
