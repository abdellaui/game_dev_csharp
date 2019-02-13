using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T8A1Enemy : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] LayerMask layermask = default;
    GameObject player;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }  
    
    void Start()
    {
        player = FindObjectOfType<T8PlayerController>().gameObject;    
    }

    void Update()
    {
        var hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position, Mathf.Infinity, layermask);
        if (hit)
        {
            if (hit.collider.tag == "Player")
            {
                Vector2 move = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                rb.MovePosition(move);
            }
        }
    }
}
