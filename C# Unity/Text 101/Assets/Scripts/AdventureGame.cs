using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    //variavel continua privada, mas podera ser modificada no unity
    [SerializeField] Text textoAtualizado;
    [SerializeField] Estado estadoInicial;

    Estado estadoAtual;

    // Start is called before the first frame update
    void Start()
    {
        estadoAtual = estadoInicial;
        textoAtualizado.text = estadoAtual.RetornaHistoria();
    }

    // Update is called once per frame
    void Update()
    {
        AdministrarEstado();
    }

    private void AdministrarEstado()
    {
        //jeito para declarar a variável e já atribuir valor de forma mais rápida (atalho)
        var proximoEstado = estadoAtual.RetornaProximo();
        for (int index = 0; index < proximoEstado.Length; index++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + index))
            {
                estadoAtual = proximoEstado[index];   
            }
        }
        textoAtualizado.text = estadoAtual.RetornaHistoria();
    }
}