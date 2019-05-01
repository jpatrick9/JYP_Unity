using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int score = 0, lives = 3;
    public GameObject livesHolder, gameOverPanel;

    public Text scoreText, livesText;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecrementLives()
    {
        if (lives > 0)
        {
            lives--;
            livesText.text = lives.ToString();
            livesHolder.transform.GetChild(lives).gameObject.SetActive(false);
        }

        if (lives <= 0)
        {
            GameOver();
        }

    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();        
    }

    public void GameOver()
    {
        CandySpawner.instance.StopSpawn();
        GameObject.Find("Player").GetComponent<PlayerController>().canMove = false;
        gameOverPanel.SetActive(true);
    }
}
