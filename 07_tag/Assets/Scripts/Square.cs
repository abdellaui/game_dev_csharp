using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    Animator anim;
    void PrintStateChange()
    {
        Debug.Log("State Changed");
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.SetTrigger("isJump");
        }
        else
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            anim.SetTrigger("isShield");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            anim.SetBool("isRotate", !anim.GetBool("isRotate"));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            anim.SetTrigger("isHit");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            anim.SetTrigger("isAnim1");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            anim.SetTrigger("isAnim2");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            anim.SetTrigger("isAnim3");
        }
    }
}
