using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class Player : MonoBehaviour
{

    public Slider healthSlider;

    public Text healthText;

    public float speed = 10;
    
    private Rigidbody2D rb;

    private Vector2 moveAmount;

    public float health;

    public float maxHealth;

    public Animator animator;

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthSlider.value = health;
        SetHealthText();
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
        //playerStats.DealDamage(damageAmount)
        health -= damageAmount;
        SetHealthText();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    float CalculateHealthPercentage()
    {
        return health / maxHealth;
    }

    private void SetHealthText()
    {
        healthSlider.value = CalculateHealthPercentage();
        healthText.text = Mathf.Ceil(health).ToString() + " / " + Mathf.Ceil(maxHealth).ToString();
    }
}