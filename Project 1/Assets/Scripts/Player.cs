using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int score;
    public int Health;
    public GameObject winPanel;
    public GameObject GameOverPanel;
    public GameObject PauseMenu;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI ScoreText;
    public static Player instance;
    public GameObject[] HealthImage;
    public ParticleSystem effect;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
        score = 0;
        Health = 3;
    }

    private void Update()
    {
        if(Health <= 0)
        {
            GameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }

        if (score >= 7)
        {
            if (!effect.IsAlive(true))
            {
              winPanel.SetActive(true);
              Time.timeScale = 0;
            }
        }

        HealthText.text = "Health : " + Health.ToString();
        ScoreText.text = "Score : " + score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
