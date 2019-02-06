using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareV1 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Camera.main.ViewportToWorldPoint(Vector3.zero + new Vector3(0, 0, 10));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.up + Vector3.right) * Time.deltaTime;
    }
}
