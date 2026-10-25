using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private Text scoreText;
    public int score = 0;
    public Text healthText;
    public Text ammoText;
    public Text enemyText;
    public Text messageText;
    public int enemiesRemaining = 0;
    private bool gameEnded = false;
    public bool GameEnded => gameEnded;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    void Start()
    {
        UpdateScore();
        UpdateHealth(100);

        enemiesRemaining = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        UpdateEnemies();

        messageText.text = "";
    }
    
    void Update()
    {
        if (gameEnded && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score.ToString();

    }

    void UpdateScore()
    {
        scoreText.text = "Score : " + score;
    }
    public void UpdateHealth(int health)
    {
        healthText.text = "PV : " + health;
    }
    public void UpdateAmmo(int ammo)
    {
        ammoText.text = "Munitions : " + ammo;
    }
    
    public void EnemyKilled()
    {
        enemiesRemaining = Mathf.Max(0, enemiesRemaining - 1);
        UpdateEnemies();

        if (enemiesRemaining == 0)
        {
            Win();
        }
    }

    void UpdateEnemies()
    {
        enemyText.text = "Ennemis : " + enemiesRemaining;
    }
    public void Win()
    {
        if (gameEnded) return;

        gameEnded = true;
        messageText.text = "VICTOIRE !\nAppuie sur R pour recommencer";
        Time.timeScale = 0f;
    }
    public void GameOver()
    {
        if (gameEnded) return;

        gameEnded = true;
        messageText.text = "GAME OVER\nR pour recommencer";
        Time.timeScale = 0f;
    }
}
