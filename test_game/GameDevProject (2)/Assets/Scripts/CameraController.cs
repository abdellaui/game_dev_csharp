using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] PlayerController player;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;    
    }

    private void LateUpdate()
    {
        if (!player.CameraIsAnimated) { 
        transform.position = player.transform.position + offset;
        }
    }
}
