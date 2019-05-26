﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float attackDelay = 2f;
    private Animator anim;
    private Rigidbody2D rb;
    private GameObject player;
    private BoxCollider2D[] colliders;
    private SpriteRenderer[] spriteRenderers;
    private SpriteRenderer sr;


    private int health = 120;
    public bool isFacingRight = false;
    [SerializeField] bool IsAttacking = false;
    private bool readyToAttack = true;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        colliders = GetComponentsInChildren<BoxCollider2D>();
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0)
        {

            if (transform.position.x - player.transform.position.x < 0 && !isFacingRight)
            {
                Flip();
            }

            if (transform.position.x - player.transform.position.x > 0 && isFacingRight)
            {
                Flip();
            }
        }

    }

    private void FixedUpdate()
    {
        if (health > 0)
        {
            if (!GameManager.instance.isFinished)
            {
                float distance = Vector3.Distance(transform.position, player.transform.position);

                if (distance > 1.6f)
                {
                    Vector2 move = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                    rb.MovePosition(move);
                    anim.SetInteger("AnimState", 2);
                }
                else
                {
                    anim.SetInteger("AnimState", 1);
                    if (readyToAttack)
                    {
                        readyToAttack = false;
                        StartCoroutine(Attack());
                    }
                    rb.velocity = Vector2.zero;
                }

            }else
            {
                anim.SetInteger("AnimState", 1);
            }
        }


    }

    private IEnumerator Attack()
    {
        if (!IsAttacking)
        {
            anim.SetTrigger("Attack");
        }
        yield return new WaitForSeconds(attackDelay);

        readyToAttack = true;
    }

    public void Damage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
            anim.ResetTrigger("Attack");
            anim.SetTrigger("Hurt");
            MusicManager.instance.PlayShot(5);

            rb.AddForce((isFacingRight ? Vector2.left : Vector2.right), ForceMode2D.Impulse);
            StartCoroutine(ResetVelocity());

            if (health <= 0)
            {
                StopAllCoroutines();
                rb.velocity = Vector3.zero;
                StartCoroutine(Die());
            }
        }
    }

    private IEnumerator ResetVelocity()
    {
        yield return new WaitForSeconds(1f);
        rb.velocity = (isFacingRight ? Vector2.left : Vector2.right) * 0.1f;
    }

    private IEnumerator Die()
    {
  
        anim.SetTrigger("Death");
        GameManager.instance.Kill();
        yield return new WaitForSeconds(1.8f);

        Destroy(gameObject);
    }

    // Flip X - Axis from Player and Collider
    private void Flip()
    {
        foreach (BoxCollider2D col in colliders)
            col.offset = new Vector2(-1 * col.offset.x, col.offset.y);

        isFacingRight = !isFacingRight;
        sr.flipX = !sr.flipX;
    }
}
