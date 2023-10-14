using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem: MonoBehaviour
{
    Animator animator;
    Defender defender;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Defender>())
        {
            animator.SetBool("NearbyEnemy", true);
            defender = other.GetComponent<Defender>();
        }
        else if (other.GetComponent<GameOverCollider>())
        {
            Destroy(gameObject, 4);
        }
    }

    public void GolemDamager(int damage)
    {
        GetComponent<AudioSource>().Play();
        var defenderHealth = defender.GetComponent<Health>();
        defenderHealth.DealDamage(damage);
        if (defenderHealth.HealthValor() <= 0)
        {
            animator.SetBool("NearbyEnemy", false);
        }
    }

}
