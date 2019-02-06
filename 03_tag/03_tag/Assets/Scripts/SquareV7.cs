using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareV7 : MonoBehaviour
{
    int countFrames = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Camera.main.ViewportToWorldPoint(Vector3.down + new Vector3(0, 0, 10));
    }

    // Update is called once per frame
    void Update()
    {
        countFrames = (countFrames + 1) % 50;

        if (countFrames < 20)
        {

            transform.gameObject.GetComponent<SpriteRenderer>().size += Vector2.one;
            transform.position += Vector3.up * Time.deltaTime;
        }
        else
        {

            transform.gameObject.GetComponent<SpriteRenderer>().size -= Vector2.one;
            transform.position += Vector3.right * Time.deltaTime;
        }
    }
}
