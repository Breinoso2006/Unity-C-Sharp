using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    // Variáveis globais usadas no programa
    int min, max, chute;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        max = 1000;
        min = 1;
        chute = 500;

        Debug.Log("Bem-vindo ao number wizard");
        Debug.Log("Pense em um número...");
        Debug.Log("O máximo é: " + max);
        Debug.Log("O mínimo é: " + min);
        Debug.Log("Primeiramente, é maior ou menor que " + chute + "?");
        Debug.Log("Seta pra cima para maior, seta para baixo para menor, enter para correto");
        max = max + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Seta pra cima apertada ");
            min = chute;
            ProximoChute();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Seta pra baixo apertada ");
            max = chute;
            ProximoChute();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Ora ora, parece que temos um Xeroque Rolmes aqui");
            StartGame();
        }
        void ProximoChute()
        {
            chute = (min + max) / 2;
            Debug.Log("É maior ou menor que " + chute + "?");
        }
    }
}
