using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameSession : MonoBehaviour
{
    //Parametros de Configuracao
    [Range(1f,2f)][SerializeField] float velocidade = 1f;
    [Range(1, 10)] [SerializeField] int pontosPorBlocoDestruido = 1;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool autoPlay = false;

    //Variaveis de estado
    [SerializeField] int score = 0;

    private void Awake()
    {
        int contadorGameStatus = FindObjectsOfType<GameSession>().Length;
        if(contadorGameStatus > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void Update()
    {
        Time.timeScale = velocidade;
    }

    public void AdicionaAoScore()
    {
        score += pontosPorBlocoDestruido;
        scoreText.text = "Score: " + score.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool AutoPlay()
    {
        return autoPlay;
    }

}
