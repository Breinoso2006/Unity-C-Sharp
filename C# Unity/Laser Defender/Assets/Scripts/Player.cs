using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Player : MonoBehaviour
{
    //Parametros de configuração
    [Header("Player Movement")]
    [SerializeField] float moveVelocity = 10f;
    [SerializeField] float xBorder = 1f;
    [SerializeField] float yBorder = 1f;
    [SerializeField] int health = 200;

    [Header("Projectile")]
    [SerializeField] float fireVelocity = 10f;
    [SerializeField] float timeBetweenFires = 0.2f;
    [SerializeField] [Range(0, 1)] float projectileSoundVolume = 0.7f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] AudioClip projectileSound;

    [Header("Damage Taken")]
    [SerializeField] [Range(0, 1)] float damageTakenSoundVolume = 0.7f;
    [SerializeField] AudioClip damageTakenSound;

    [Header("Explosion")]
    [SerializeField] float durationOfExplosion = 1f;
    [SerializeField] [Range(0, 1)] float explosionSoundVolume = 0.7f;
    [SerializeField] GameObject deathExplosion;
    [SerializeField] AudioClip explosionSound;

    Coroutine fireCoroutine;

    //Parâmetros para  câmera
    float xMin;
    float xMax;
    float yMin;
    float yMax;

    // Start is called before the first frame update
    void Start()
    {
        MoveLimits();
    }

    private void MoveLimits()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + xBorder;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - xBorder;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + yBorder;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - yBorder;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
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
        FindObjectOfType<Level>().LoadGameOver();
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathExplosion, gameObject.transform.position, Quaternion.identity);
        Destroy(explosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, explosionSoundVolume);
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            fireCoroutine = StartCoroutine(ContinuousFire());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(fireCoroutine);
        }
    }

    IEnumerator ContinuousFire()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, fireVelocity);
            AudioSource.PlayClipAtPoint(projectileSound, Camera.main.transform.position, projectileSoundVolume);
            yield return new WaitForSeconds(timeBetweenFires);
        }
    }

    private void Move()
    {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveVelocity;
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveVelocity;
        var newXPosX = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newXPosY = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPosX, newXPosY);
    }

    public int GetHealth()
    {
        return health;
    }
}
