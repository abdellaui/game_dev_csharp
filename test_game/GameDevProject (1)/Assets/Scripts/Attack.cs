using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
    protected int damage { get; set; } = 10;

    private Collider2D col;
    protected bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!transform.parent.gameObject.GetComponent<PlayerController>().isFacingRight && isFacingRight)
        {
            Flip();
        }

        if (transform.parent.gameObject.GetComponent<PlayerController>().isFacingRight && !isFacingRight)
        {
            Flip();
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Destructibel"))
        {
            collision.SendMessageUpwards("Damage", damage);
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Destructibel"))
        {

        }
    }

    protected void Flip()
    {
        col.offset = new Vector2(-1 * col.offset.x, col.offset.y);

        isFacingRight = !isFacingRight;
    }
}
