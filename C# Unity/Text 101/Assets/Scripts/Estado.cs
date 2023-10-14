using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//cria opção no unity para criar um estado novo da história
[CreateAssetMenu(menuName = "Estado")]
public class Estado : ScriptableObject
{
    //primeiro numero é o tamanho minimo e o segundo é o maximo antes de dar scroll
    [TextArea(10,14)] [SerializeField] string historia;

    //criamos um vetor, onde o tamanho e os elementos são determinados no próprio unity
    [SerializeField] Estado[] proximoEstado;

    public string RetornaHistoria()
    {
        return historia;
    }

    public Estado[] RetornaProximo()
    {
        return proximoEstado;
    }
}
