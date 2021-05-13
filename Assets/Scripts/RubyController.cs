using System;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public int maxHealth = 5;
    public float speed = 3.5f;
    public int health => currentHealth;
    public float timeInvincible = 2.0f;

    private Rigidbody2D rb2D;
    private float horizontal;
    private float vertical;
    private int currentHealth;
    private bool isInvincible;
    private float invincibleTimer;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }
    }

    private void FixedUpdate()
    {
        var position = rb2D.position;

        position.x += speed * horizontal * Time.deltaTime;
        position.y += speed * vertical * Time.deltaTime;

        rb2D.MovePosition(position);
    }

    public void ChangeHealth(int damage)
    {
        if (damage < 0)
        {
            if (isInvincible)
            {
                return;
            }
            
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + damage, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
