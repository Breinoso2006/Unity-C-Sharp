using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarregarScene : MonoBehaviour
{
    public void CarregaProximaScene()
    {
        int indexSceneAtual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indexSceneAtual+1);
    }
    public void CarregaPrimeiraScene()
    {
        SceneManager.LoadScene(0);
    }
    public void Sair()
    {
        Application.Quit();
    }

}
