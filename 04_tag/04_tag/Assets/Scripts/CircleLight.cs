using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleLight : MonoBehaviour
{
    public float waitTime = 1f;
    IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(waitTime);

        transform.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value);

        yield return StartCoroutine(ChangeColor());

    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeColor());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
