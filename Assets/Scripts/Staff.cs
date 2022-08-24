using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Sprite staff;
    // Start is called before the first frame update

    private void Start() 
    {
        sprite= gameObject.GetComponent<SpriteRenderer>();
        sprite.sprite = staff;
    }
    public void FlipSprite()
    {
        sprite.flipX = true;
        Debug.Log("FLIPOU");
    }

    public void Volta()
    {
        sprite.flipX = false;
        Debug.Log("FLIPOU");
    }
}
