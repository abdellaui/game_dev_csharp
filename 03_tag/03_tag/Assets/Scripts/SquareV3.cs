using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareV3 : MonoBehaviour
{
    int countFrames = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Camera.main.ViewportToWorldPoint(Vector3.one + new Vector3(0, 0, 10));
    }

    // Update is called once per frame
    void Update()
    {
        countFrames = (countFrames + 1) % 30;

        if (countFrames < 10)
        {
            transform.position += Vector3.down * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * Time.deltaTime;
        }
    }
}
