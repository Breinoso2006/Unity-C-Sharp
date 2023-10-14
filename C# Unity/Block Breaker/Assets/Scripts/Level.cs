using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Build.Content;
using UnityEngine;

public class Level : MonoBehaviour
{
    //Parametros
    [SerializeField] int quantidadeBlocos;

    //Referencia em cache
    CarregarScene carregaProxima;

    private void Start()
    {
        //apenas associação
        carregaProxima = FindObjectOfType<CarregarScene>();
    }

    public void ContaBlocos() 
    {
        quantidadeBlocos++;
    }

    public void ContaBlocosDestruidos()
    {
        quantidadeBlocos--;
        if (quantidadeBlocos <= 0)
        {
            carregaProxima.CarregaProximaScene();
        }
    }
    
}
