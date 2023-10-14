using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Healh")]
    [SerializeField] float health = 100;

    [Header("Score Points")]
    [SerializeField] int deathScore = 0;

    [Header("Projectiles")]
    float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float timeBetweenFires = 0.5f;
    [SerializeField] [Range(0, 1)] float projectileSoundVolume = 0.7f;
    [SerializeField] GameObject projectile;
    [SerializeField] AudioClip projectileSound;

    [Header("Damage Taken")]
    [SerializeField] [Range(0, 1)] float damageTakenSoundVolume = 0.7f;
    [SerializeField] AudioClip damageTakenSound;

    [Header("Explosion")]
    [SerializeField] float durationOfExplosion = 1f;
    [SerializeField] [Range(0,1)] float explosionSoundVolume = 0.7f ;
    [SerializeField] GameObject deathExplosion;
    [SerializeField] AudioClip explosionSound;

    private void Start()
    {
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    private void Update()
    {
        CountDownAndShot();
    }

    private void CountDownAndShot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0)
        {
            Fire();
            shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, - projectileSpeed);
        AudioSource.PlayClipAtPoint(projectileSound, Camera.main.transform.position, projectileSoundVolume);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        AudioSource.PlayClipAtPoint(damageTakenSound, Camera.main.transform.position, damageTakenSoundVolume);
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        FindObjectOfType<GameSession>().AddToScore(deathScore);
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathExplosion, gameObject.transform.position, Quaternion.identity);
        Destroy(explosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, explosionSoundVolume);
    }
}
