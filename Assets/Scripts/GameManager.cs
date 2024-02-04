using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Public variables accessible in the Unity Inspector
    public GameObject block;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate;

    // References to UI elements
    public GameObject tapText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText; // Reference to the UI element displaying the high score

    // New variables for the win condition
    //public int winCondition;    // Number of crates required to win
    public string nextSceneName;  // Name of the next scene to load

    public bool gameStarted = false;
    private int score = 0;
    private int highScore = 0; // Variable to store the high score

    private float nextSpawnTime = 0f;

    void Start()
    {
        LoadHighScore(); // Load the high score at the start of the game
        UpdateHighScoreText(); // Update the UI with the current high score
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameStarted)
        {
            gameStarted = true;
            StartSpawning();
            tapText.SetActive(false);
        }
    }

    private void StartSpawning()
    {
        InvokeRepeating("SpawnBlock", 0.5f, spawnRate);
    }

    private void SpawnBlock()
    {
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);

        Instantiate(block, spawnPos, Quaternion.identity);

        score++;
        scoreText.text = score.ToString();

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
            UpdateHighScoreText();
        }

        //CheckWinCondition();
    }

/*    private void CheckWinCondition()
    {
        if (score >= winCondition\\)
        {
            UpdateHighScore();
            SceneManager.LoadScene(nextSceneName);
        }
    }*/

 /*   private void UpdateHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
            UpdateHighScoreText();
        }
    }*/

    private void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void UpdateHighScoreText()
    {
        highScoreText.text = "High Score: " + highScore.ToString();
    }
}