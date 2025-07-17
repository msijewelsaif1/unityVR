using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    public GameObject gameOverScreen;

    private float scoreTimer = 0f;
    public float scoreRate = 1f; // 1 point per second

    public BirdScript bird;

    void Update()
    {
        if (bird != null && bird.birdIsAlive)
        {
            scoreTimer += Time.deltaTime;

            if (scoreTimer >= 1f / scoreRate)
            {
                playerScore += 1;
                scoreText.text = playerScore.ToString();
                scoreTimer = 0f;
            }
        }
    }

    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
