using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Wuerfel : MonoBehaviour
{
    float speed = 200f;
    Vector3 startPos = default;
    // Start is called before the first frame update
    void Start()
    {
        if (Application.IsPlaying(gameObject))
        {

            Vector3 intV = new Vector3((int)transform.position.x, (int)transform.position.y, (int)transform.position.z);
            startPos = intV;
            transform.position = startPos;
        }
 
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.IsPlaying(gameObject))
        {

            Vector3 intV = new Vector3((int)transform.position.x, (int)transform.position.y, (int)transform.position.z);
            startPos = intV;
            transform.position = startPos;
        }
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody>().AddForce((transform.forward + Vector3.up) * speed);
            GetComponent<Rigidbody>().AddTorque(new Vector3(Random.value, Random.value, Random.value) * speed);
            GetComponent<Rigidbody>().useGravity = true;

        }


        if (Input.GetMouseButtonDown(1))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            GetComponent<Rigidbody>().useGravity = false;
            transform.position = startPos;
            transform.rotation = Quaternion.identity;
        }
    }
}
