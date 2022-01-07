using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject livesHolder;
    public GameObject gameOverPanel;

    public Text scoreText;

    int score = 0;
    int lives = 3;

    bool gameOver = false;

    
    
    private void Awake()
    {
        Instance = this;
    }
   

    public void IncrementScore()
    {
        if (!gameOver)
        {
            score++;
            scoreText.text = score.ToString();
        }
        
    }

    public void DecreaseLife()
    {
        if (lives > 0)
        {
            lives--;
            livesHolder.transform.GetChild(lives).gameObject.SetActive(false);
        }

        if (lives <= 0)
        {
            gameOver = true;
            GameOver();
        }
        
    }
    public void GameOver()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().canMove = false;
        CandySpawner.Instance.StopSpawningCandies();
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
