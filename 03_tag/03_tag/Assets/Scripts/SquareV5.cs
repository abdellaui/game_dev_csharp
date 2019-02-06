using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareV5 : MonoBehaviour
{

    private int countFrame = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Camera.main.ViewportToWorldPoint(Vector3.up + new Vector3(0, 0, 10));
    }

    // Update is called once per frame
    void Update()
    {
        countFrame = (countFrame + 1)  % 360;
        transform.rotation = Quaternion.Euler(0, countFrame, 0);

        transform.position += (Vector3.down + Vector3.right) * Time.deltaTime;
    }
}
