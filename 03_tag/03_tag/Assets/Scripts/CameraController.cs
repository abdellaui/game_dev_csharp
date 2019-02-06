using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject player = default;
    private bool cameraFollow = false;
    private Vector3 offset;
    void Start()
    {
        offset = transform.position - player.transform.position * 0.2f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            cameraFollow = !cameraFollow;
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (cameraFollow)
        {
            transform.position = player.transform.position + offset;
        }
    }
}
