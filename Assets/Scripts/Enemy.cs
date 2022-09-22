using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;

    public int maxHealth;

    [HideInInspector]
    public Transform player;

    public float speed;

    public float timeBetweenAttacks;

    public int damage;

    public HealthBarBehaviour healthBar;


    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        healthBar.SetHealth(health, maxHealth);
    }
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        healthBar.SetHealth(health, maxHealth);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
