using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;

    [SerializeField] Text livesText;
    [SerializeField] Text coinsText;

    int coins = 0;

    private void Awake()
    {
        int NumberGameSessions = FindObjectsOfType<GameSession>().Length;
        if (NumberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else 
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        livesText.text = playerLives.ToString();
        coinsText.text = coins.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    private void TakeLife()
    {
        playerLives--;
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(WaitToLoad(currentScene));
    }

    IEnumerator WaitToLoad(int Scene)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(Scene);
    }

    private void ResetGameSession()
    {
        playerLives = 3;
        coinsText.text = "0";
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    public void AddCoin(int amount)
    {
        coins += amount;
    }
}
