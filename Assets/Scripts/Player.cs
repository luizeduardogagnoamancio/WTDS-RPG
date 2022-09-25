using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10;
    
    private Rigidbody2D rb;

    private Vector2 moveAmount;

    public int health;

    public int maxHealth;

    public Animator animator;

    public HealthBarBehaviour healthBar;

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthBar.SetHealth(health, maxHealth);
    }

    private void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = moveInput.normalized * speed;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
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