using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerController : MonoBehaviour
{
    [SerializeField] GameObject target = default;
    private float speed = default;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        speed = SceneLoader.mSliderValue;
        Vector3 v3 = transform.position;
        v3.x = Mathf.Lerp(target.gameObject.transform.position.x, v3.y, Time.deltaTime * speed);
        transform.position = v3;
    }
}
