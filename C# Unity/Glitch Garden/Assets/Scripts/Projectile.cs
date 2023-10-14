using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(3f,5f)] [SerializeField] float projectileSpeed = 1f;
    [SerializeField] int projectileDamage = 100;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        
        if (health)
        {
            health.DealDamage(projectileDamage);
            Destroy(gameObject);
        }
    }
}
