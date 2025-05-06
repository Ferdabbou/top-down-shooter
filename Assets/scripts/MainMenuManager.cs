using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
 
    public void StartGame()
    {
        SceneManager.LoadScene("1"); // Replace with your game scene name
    }

    public void OpenOptions()
    {
        // Optional: Add options panel later
        Debug.Log("Options clicked");
    }

    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}