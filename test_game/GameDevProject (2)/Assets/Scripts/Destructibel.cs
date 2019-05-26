using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructibel : MonoBehaviour
{
    private int health = 40;
    private Animator anim;
    private GameObject food;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        food = transform.Find("Food").gameObject;
        sr = GetComponent<SpriteRenderer>();

        food.SetActive(false);
    }
    

    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            StartCoroutine("Die");
        }
        anim.SetTrigger("barrelHitTrigger");
    }

    private IEnumerator Die()
    {
        anim.SetBool("barrelDestroy", true);

        yield return new WaitForSeconds(0.7f);
        sr.enabled = false;
        food.SetActive(true);
    }
}
