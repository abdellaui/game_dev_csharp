using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddlePlayer : MonoBehaviour
{
    float speed = 1.0f;
    Vector3 leftBottom;
    Vector3 topRight;

    void Start()
    {
        leftBottom = Camera.main.ViewportToWorldPoint(Vector3.zero);
        topRight = Camera.main.ViewportToWorldPoint(Vector3.one);
    }

    // Update is called once per frame
    void Update()
    {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        transform.position = new Vector3(
        Mathf.Clamp(xPos, leftBottom.x + .75f, topRight.x - .75f),
        transform.position.y,
        transform.position.z);
    }
}
