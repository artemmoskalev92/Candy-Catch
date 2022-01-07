using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject livesHolder;

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
            print("Lives remain: " + lives);
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
        CandySpawner.Instance.StopSpawningCandies();
        GameObject.Find("Player").GetComponent<PlayerController>().canMove = false;
        print("Game Over!");
    }
}
