using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    [SerializeField] float moveLimiter = 0.7f;

    public SpriteRenderer spriteRenderer;
    public Sprite front;
    public Sprite back;
    public Sprite right;
    public Sprite left;

    //public float runSpeed = 1.0f;
    [SerializeField] float runSpeed = 10f;

    void Start ()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down  
    }

    //h = -1 e v = 0 esquerda
    //h = 1 e v = 0 direita

    //h = 0 e v = 1 cima
    //h = 0 e v = -1 baixo
    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        } 

        if (horizontal == -1 && vertical == 0)
        {
            spriteRenderer.sprite = left;
        }
        
        else if (horizontal == 1 && vertical == 0)
        {
            spriteRenderer.sprite = right;
        }
        
        else if (horizontal == 0 && vertical == 1)
        {
            spriteRenderer.sprite = back;
        }else
        {
            spriteRenderer.sprite = front;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        
    }

    
}