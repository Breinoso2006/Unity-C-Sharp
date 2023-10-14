using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheFox : MonoBehaviour
{
    float movementSpeed;
    Animator animator;
    Defender defender;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
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
    public void TheFoxDamager(int damage)
    {
        GetComponent<AudioSource>().Play();
        var defenderHealth = defender.GetComponent<Health>();
        defenderHealth.DealDamage(damage);
        if (defenderHealth.HealthValor() <= 0)
        {
            animator.SetBool("NearbyEnemy", false);
        }
    }

    public float SetMovementSpeed(float movementSpeed)
    {
        this.movementSpeed = movementSpeed;
        return movementSpeed;
    }

}
