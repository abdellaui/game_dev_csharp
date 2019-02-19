using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 5f;
        }
        else
        {
            speed = 1f;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Rotate(new Vector3(0, 1, 0), 1f);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Rotate(new Vector3(0, -1, 0), 1f);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            // down
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }

    }
}
