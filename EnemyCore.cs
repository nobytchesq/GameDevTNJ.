using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyshu : MonoBehaviour {

    public int health = 100;
    public GameObject deathEffect;
    [SerializeField] FloatingHealthEnemy healthbar;
    Rigidbody2D rb;
    int maxHealth;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        healthbar = GetComponentInChildren<FloatingHealthEnemy>();
        maxHealth = health;
    }
    public void TakeDamage (int damage)
    {
        health -= damage;
        healthbar.UpdateHealthBar(health, maxHealth);
        if (health <= 0)
        {
            Die();
        }
    }

    void Die ()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
