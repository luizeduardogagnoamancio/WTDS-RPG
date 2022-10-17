using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class Player : MonoBehaviour
{

    public Slider healthSlider;

    public Text healthText;

    public Slider expSlider;

    public Text expText;

    public Text levelText;

    public float speed = 10;
    
    private Rigidbody2D rb;

    private Vector2 moveAmount;

    public float health;

    public float maxHealth;

    public Animator animator;

    public float exp = 0;

    public float maxExp = 100;

    public int level;

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthSlider.value = health;
        expSlider.value = exp;
        SetHealthText();
        SetExpText();
        SetLvlText();
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
        Debug.Log(level);
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

    float CalculateExpPercentage()
    {
        return exp / maxExp;
    }

    private void SetHealthText()
    {
        healthSlider.value = CalculateHealthPercentage();
        healthText.text = Mathf.Ceil(health).ToString() + " / " + Mathf.Ceil(maxHealth).ToString();
    }

    private void SetExpText()
    {
        expSlider.value = CalculateExpPercentage();
        expText.text = Mathf.Ceil(exp).ToString() + " / " + Mathf.Ceil(maxExp).ToString();
    }

    private void SetLvlText()
    {
        levelText.text = "Lvl . " + level.ToString();
    }



    public void GainExp(float amount)
    {
        if (exp >= maxExp)
        {
            exp -= maxExp;
            level += 1;
            SetLvlText();
            maxExp += maxExp - 50;
        }
        else
        {
            exp += amount;
        }
        
        SetExpText();
    }
    
}