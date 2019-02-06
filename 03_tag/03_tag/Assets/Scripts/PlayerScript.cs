using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float speed = default;
    Vector3 leftBottom;
    Vector3 topRight;
    // Start is called before the first frame update
    Vector3 PositionClamper(Vector3 k) {
        float x = Mathf.Clamp(k.x, leftBottom.x-2, topRight.x-2);
        float y = Mathf.Clamp(k.y, leftBottom.y, topRight.y);
        return new Vector3(x, y, k.z);
    }
    void Start()
    {
        speed = 10;
        leftBottom = Camera.main.ViewportToWorldPoint(Vector3.zero);
        topRight = Camera.main.ViewportToWorldPoint(Vector3.one);
    }

    // Update is called once per frame
    void Update()
    {
 

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
            transform.position = PositionClamper(transform.position);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * Time.deltaTime * speed;
            transform.position = PositionClamper(transform.position);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
            transform.position = PositionClamper(transform.position);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * Time.deltaTime * speed;
            transform.position = PositionClamper(transform.position);
        }
    }
}
