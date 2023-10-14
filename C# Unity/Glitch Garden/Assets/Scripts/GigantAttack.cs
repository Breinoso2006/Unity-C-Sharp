using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GigantAttack : MonoBehaviour
{
    Animator animator;
    Attacker attacker;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        animator.SetBool("NearbyEnemy", true);
        if (other.GetComponent<Attacker>())
        {
            attacker = other.GetComponent<Attacker>();
        }
    }

    public void GigantDamager(int damage)
    {
        GetComponent<AudioSource>().Play();
        var attackerHealth = attacker.GetComponent<Health>();
        attackerHealth.DealDamage(damage);
        if (attackerHealth.HealthValor() <= 0)
        {
            animator.SetBool("NearbyEnemy", false);
        }
    }

}