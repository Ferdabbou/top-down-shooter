using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI waveText;
    public Image healthBarFill;
    public int currentScore = 0;
    public TMP_Text enemiesAliveText;

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateScore(currentScore);
    }


    private void Awake()
    {
        instance = this;
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateWave(int wave)
    {
        waveText.text = "Wave " + wave;
    }

    public void UpdateHealth(float current, float max)
    {
        float percent = Mathf.Clamp01(current / max);
        healthBarFill.rectTransform.localScale = new Vector3(percent, 1f, 1f);
    }

    public void UpdateEnemiesAlive(int count)
    {
        enemiesAliveText.text = "Enemies: " + count;
    }

    public void HideHUD()
    {
        gameObject.SetActive(false); // Disables the HUD canvas
    }



}
