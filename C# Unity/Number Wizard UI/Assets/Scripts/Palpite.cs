using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Palpite : MonoBehaviour
{
    [SerializeField] int max;
    [SerializeField] int min;
    [SerializeField] TextMeshProUGUI textoChute;

    int chute;

    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        ProximoChute();
    }

    public void ClickMais()
    {
        min = chute + 1;
        ProximoChute(); ;
    }

    public void ClickMenos()
    {
        max = chute - 1 ;
        ProximoChute();
    }

    public void ProximoChute()
    {
        chute = UnityEngine.Random.Range(min,max +1);
        textoChute.text = chute.ToString();
    }
}
