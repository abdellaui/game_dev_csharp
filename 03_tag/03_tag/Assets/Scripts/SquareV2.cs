using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareV2 : MonoBehaviour
{
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(Random.value, Random.value, 0);
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f) + new Vector3(0, 0, 10));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Time.deltaTime;
    }
}
