using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip audioCoin;
    [SerializeField] int amount = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(audioCoin, transform.position);
        FindObjectOfType<GameSession>().AddCoin(amount);
        Destroy(gameObject);
    }

}
