using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{

    [SerializeField] Text lifeText = default;
    [SerializeField] Text deathsText = default;
    [SerializeField] private bool canJump = false;
    private float jumpSpeed = 12f;
    private float isJumping = -1f;
    private float speed = 5f;
    private Rigidbody2D rb = default;

    private int life = 3;
    private int deaths = 0;

    private void Awake()
    {
        deaths = PlayerPrefs.GetInt("deaths");
        life = PlayerPrefs.GetInt("life");
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        canJump |= collision.gameObject.tag == "Ground";
        if (collision.gameObject.tag == "Boden")
        {
            Hit();
            transform.position = Vector3.zero;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Hit();
        }
    }

    void Hit()
    {

        PlayerPrefs.SetInt("life", --life);
        if (life <= 0)
        {
            Die();
        }
        else {
            rb.AddForce(Vector2.left * 7, ForceMode2D.Impulse);
        }
    }
    void Die()
    {
        life = 3;
        PlayerPrefs.SetInt("life", life);
        PlayerPrefs.SetInt("deaths", ++deaths);

        transform.position = Vector3.zero;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = SceneLoader.mSliderValue * 5;
        lifeText.text = life.ToString();
        deathsText.text = deaths.ToString();


        if (Input.GetButtonDown("Jump") && canJump)
        {
            rb.AddForce(Vector2.up * 7, ForceMode2D.Impulse);
            canJump = false;
        }
    }


    void FixedUpdate()
    {

        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

    }
}
