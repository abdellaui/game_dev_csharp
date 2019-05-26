using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    private BoxCollider2D[] colliders;
    private Color orgColor;
    public bool isFacingRight = true;
    private bool isDead = false;
    public int speed = 7;
    public float animationTime = 0.75f;

    public int maxHealth = 200;
    private int health = 200;

    private void Healing(int heal)
    {
        if (health + heal > maxHealth) health = maxHealth;
        health += heal;
        HealthBar.instance.UpdateBar((float)health / maxHealth);
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        colliders = GetComponentsInChildren<BoxCollider2D>();
        orgColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                anim.SetTrigger("attack1");
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                anim.SetTrigger("attack2");
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                anim.SetTrigger("attack3");
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                anim.SetTrigger("attack4");
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("taunt", true);
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                anim.SetBool("taunt", false);
            }
        }

    }

    void FixedUpdate()
    {
        if(!isDead)
        {
            float horizontal = Input.GetAxis("Horizontal");
            anim.SetFloat("axisHorizontal", horizontal);
            Vector2 movement = new Vector2(horizontal, 0);

            if (horizontal < 0 && isFacingRight)
            {
                Flip();
            }

            if (horizontal > 0 && !isFacingRight)
            {
                Flip();
            }

            rb.velocity = movement * speed;

            if (System.Math.Abs(Input.GetAxis("Horizontal")) < 0.05)
            {
                rb.velocity = Vector2.zero;
            }
        }else
        {
            rb.velocity = Vector2.zero;
        }

    }

    // Flip X - Axis from Player and Collider
    private void Flip()
    {
        foreach (BoxCollider2D col in colliders)
            col.offset = new Vector2(-1 * col.offset.x, col.offset.y);

        isFacingRight = !isFacingRight;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    public void Damage(int damage)
    {
        health -= damage;
        if (health < 0) health = 0;

        float normalized = (float)health/ maxHealth;

        if (health <= 50 && health > 0)
        {
            anim.SetTrigger("damage2");
            StartCoroutine(HitAnimation());
            HealthBar.instance.UpdateBar(normalized);
        }
        else if (health > 50)
        {
            anim.SetTrigger("damage1");
            StartCoroutine(HitAnimation());
            HealthBar.instance.UpdateBar(normalized);
        }
        else
        {
            HealthBar.instance.UpdateBar(normalized);
            Die();
        }

    }

    private void Die()
    {
        if (!isDead)
        {
            anim.SetBool("dead", true);
            isDead = true;
            GameManager.instance.PlayerDead = true;
            foreach (Collider2D col in colliders)
                col.enabled = false;

        }
        StopAllCoroutines();
    }

    private IEnumerator HitAnimation()
    {
        Color flash = orgColor;
        flash.a = 0.3f;

        yield return new WaitForSeconds(0.4f);

        spriteRenderer.color = flash;
        yield return new WaitForSeconds(0.2f);

        spriteRenderer.color = orgColor;
        yield return new WaitForSeconds(0.4f);
    }
}
