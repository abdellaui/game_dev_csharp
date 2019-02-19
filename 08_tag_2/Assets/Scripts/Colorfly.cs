using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorfly : MonoBehaviour
{
    float speed = 2.0f;
    Animator anim;
    int shotIndex = 0;
    bool levelDone = false;

    [SerializeField] TrailRenderer trail1 = default;
    [SerializeField] TrailRenderer trail2 = default;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Orb")
        {
            MusicManager.instance.PlayShot(6 + shotIndex++);
            shotIndex = shotIndex % 4;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        trail1.transform.position = transform.position + (Vector3.right * 0.15f);
        trail2.transform.position = transform.position - (Vector3.right * 0.15f);
        GameObject.FindWithTag("Stars").transform.position = transform.position;
        anim.SetFloat("axisHorizontal", Input.GetAxis("Horizontal"));
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            transform.position += Vector3.down * Time.deltaTime * speed;
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            transform.position += Vector3.up * Time.deltaTime * speed;
        }


    }
}
