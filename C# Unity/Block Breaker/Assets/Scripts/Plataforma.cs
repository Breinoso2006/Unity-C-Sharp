using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    //Parametros de Configuração

    [SerializeField] float unidadeDeLarguraDaTela = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    //Links
    GameSession gameSessionAtual;
    Bola bolaAtual;

    private void Start()
    {
        gameSessionAtual = FindObjectOfType<GameSession>();
        bolaAtual = FindObjectOfType<Bola>();
    }

    void Update()
    {
        Vector2 posiPlataforma = new Vector2(transform.position.x , transform.position.y); //guarda a posição x e y deste elemento em questão
        posiPlataforma.x = Mathf.Clamp(PosicaoX(), minX, maxX); //limita o eixo x do elemento 
        transform.position = posiPlataforma; //a posição do elemento vai ser a o valor guardado pela variavel posiPlataforma
    }

    private float PosicaoX()
    {
        if (gameSessionAtual.AutoPlay())
        {
            return bolaAtual.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * unidadeDeLarguraDaTela; //vai guardar a posição x do mouse de acordo com a tela
        }
    }

}
