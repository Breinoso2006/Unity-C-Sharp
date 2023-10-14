using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        //Cria (caso não haja) um GameObject com o nome passado como parametro e
        //Relaciona a variavel defenderParent com o gameobject em questao
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        //Verifica se tem dinheiro suficiente para spawnar o defender e
        //caso tenha spawna e atualizar o display
        var StarDisplay = FindObjectOfType<StarsDisplay>();
        int defenderCost = defender.GetStarCost();
        if (StarDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            StarDisplay.SpendStars(defenderCost);
        }

    }

    private Vector2 GetSquareClicked()
    {
        //verifica onde foi clicado pelo mouse (coordenadas) e converte
        //este espaço para um "mundo" dentro do programa
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        worldPos = SnapToGrid(worldPos);
        return worldPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        //responsável por converter para o "mundo" desejado dentro do Unity, que seriam os
        //quadrados do jogo, onde seus centros são as coordenadas inteiras
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 worldPos)
    {
        //responsável por spawnar o defensor em questão, na posição em questão
        //e também por encaixá-lo no gameobject criado no começo do programa, de forma
        //que mantenhamos uma organização
        Defender newDefender = Instantiate(defender, worldPos, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;
    }
}
