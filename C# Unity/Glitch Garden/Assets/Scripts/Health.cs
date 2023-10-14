using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void DealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            StartCoroutine(DeathAnimation());
        }

    }

    IEnumerator DeathAnimation()
    {
        animator.SetBool("IsDead", true);
        Destroy(this.gameObject.GetComponent<BoxCollider2D>());
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }

    public int HealthValor()
    {
        return health;
    }

}
