using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco : MonoBehaviour
{

    //Parametros de configuração
    [SerializeField] AudioClip arquivoSomBlocoQuebrado;
    [SerializeField] GameObject arquivoParticulas;
    [SerializeField] Sprite[] hitSprites;

    //Referencia em cache
    Level level;

    //Variaveis de estado
    int hits = 0;

    private void Start()
    {
        ContaBlocosQuebraveis();
    }

    private void ContaBlocosQuebraveis()
    {
        //apenas associação
        level = FindObjectOfType<Level>();

        if (tag == "Quebravel")
        {
            level.ContaBlocos();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Quebravel")
        {
            Colisoes();
        }
    }

    private void Colisoes()
    {
        hits++;
        int maximoDeHits = hitSprites.Length + 1;
        if ( hits >= maximoDeHits)
        {
            DestroiBloco();
        }
        else 
        {
            ProximoSprite();
        }
    }

    private void ProximoSprite()
    {
        int spriteIndex = hits - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.Log("Sprite faltando!" + gameObject.name);
        }
    }

    private void DestroiBloco()
    {
        SomBlocoQuebrado();
        Destroy(gameObject);
        GatilhoParaParticulas();
        level.ContaBlocosDestruidos();
    }

    private void SomBlocoQuebrado()
    {
        FindObjectOfType<GameSession>().AdicionaAoScore();
        AudioSource.PlayClipAtPoint(arquivoSomBlocoQuebrado, Camera.main.transform.position);
    }

    private void GatilhoParaParticulas()
    {
        GameObject particulas = Instantiate(arquivoParticulas, transform.position, transform.rotation);
        Destroy(particulas, 1f);
    }
}
