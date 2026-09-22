using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private Text scoreText;
    public int score = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score.ToString();

    }
      public void Spawn(string enemyName)
    {
       
    }
}
