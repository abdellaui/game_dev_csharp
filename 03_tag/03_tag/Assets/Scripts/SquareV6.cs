using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareV6 : MonoBehaviour
{
    private const int frames = 150;
    private int countFrame = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f) + new Vector3(0, 0, 10));
    }

    // Update is called once per frame
    void Update()
    {
        countFrame =(countFrame + 1) % (frames * 4);

        Vector3 direction = Vector3.up;

        if (countFrame < frames)
        {
            direction = Vector3.right;
            transform.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (countFrame < frames * 2)
        {
            direction = Vector3.down;
            transform.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else if (countFrame < frames * 3)
        {
            direction = Vector3.left;
            transform.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else {
            transform.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        transform.position += direction * Time.deltaTime;
    }
}
