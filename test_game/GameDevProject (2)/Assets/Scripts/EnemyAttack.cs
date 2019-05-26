using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : Attack
{
    public EnemyAttack()
    {
        damage = 15;
    }

    void Update()
    {
        if (!transform.parent.gameObject.GetComponent<EnemyController>().isFacingRight && !base.isFacingRight)
        {
            base.Flip();
        }

        if (transform.parent.gameObject.GetComponent<EnemyController>().isFacingRight && base.isFacingRight)
        {
            base.Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.SendMessageUpwards("Damage", damage);
        }
    }
}
