using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentipedeAttack : MonoBehaviour
{
    [SerializeField] int deathDamage = 500;
    [SerializeField] float deathTime = 1;
    [SerializeField] GameObject deathExplosion;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    IEnumerator NearbyEnemy(Collider2D other)
    {
        animator.SetBool("NearbyEnemy", true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(deathTime);
        var explosion = Instantiate(deathExplosion, transform.position, Quaternion.identity);
        var attacker = other.GetComponent<Attacker>();
        attacker.GetComponent<Health>().DealDamage(deathDamage);
        Destroy(explosion, 0.5f);
        Destroy(GetComponent<BoxCollider2D>());
        Destroy(gameObject, 2);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(NearbyEnemy(other));
    }
}
