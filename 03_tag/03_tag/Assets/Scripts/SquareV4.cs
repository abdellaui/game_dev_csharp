using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareV4 : MonoBehaviour
{

    public float amplitute = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, 0) + new Vector3(0, 0, 10));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time) * amplitute, 0);
      
    }
}
