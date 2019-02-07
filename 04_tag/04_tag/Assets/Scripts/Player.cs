using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1f;

    [SerializeField] public bool isPLayer = false;
    private string cheatCode = "";

    private bool alpha1Clicked = false;
    private bool alpha2Clicked = false;
    private bool alpha3Clicked = false;
    private bool alpha4Clicked = false;
    private const int frames = 100;
    private int countFrame = 0;

    private Color rememberColor = default;
    // Start is called before the first frame update
    void Start()
    {
        rememberColor = transform.gameObject.GetComponent<SpriteRenderer>().color;
    }

    void Move1()
    {

        countFrame = (countFrame + 1 * Mathf.Clamp((int)speed, 1, 10)) % 360;
        transform.rotation = Quaternion.Euler(0, 0, countFrame);

        if (isPLayer && countFrame > 355)
        {
            transform.rotation = Quaternion.identity;
            alpha1Clicked = false;
        }
    }

    void Move2()
    {
        countFrame = (countFrame + 1 * Mathf.Clamp((int)speed, 1, 10)) % 360;
        transform.rotation = Quaternion.Euler(countFrame, 0, countFrame);

        if (isPLayer && countFrame > 355)
        {
            transform.rotation = Quaternion.identity;
            alpha2Clicked = false;
        }
    }

    void Move3()
    {
        countFrame = (countFrame + 1 * Mathf.Clamp((int)speed, 1, 3)) % (frames * 4);


        if (countFrame < frames / speed)
        {
            transform.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (countFrame < frames * 2 / speed)
        {
            transform.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else if (countFrame < frames * 3 / speed)
        {
            transform.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (countFrame < frames * 4 / speed)
        {
            transform.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        }

        if (isPLayer && countFrame > frames * 4 - 25)
        {
            transform.gameObject.GetComponent<SpriteRenderer>().color = rememberColor;
            alpha3Clicked = false;
        }
    }
    void Move4()
    {
        countFrame = (countFrame + 1 * Mathf.Clamp((int)speed, 1, 3)) % (frames * 4);

        Vector3 direction = Vector3.up;

        if (countFrame < frames)
        {
            direction = Vector3.right;

        }
        else if (countFrame < frames * 2)
        {
            direction = Vector3.down;
        }
        else if (countFrame < frames * 3)
        {
            direction = Vector3.left;
        }
        transform.position += direction * Time.deltaTime * speed;
        if (isPLayer && countFrame > frames * 4 - 25)
        {
            countFrame = 0;
            alpha4Clicked = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (alpha1Clicked || !isPLayer)
        {
            Move1();
        }
        if (alpha2Clicked || !isPLayer)
        {
            Move2();
        }
        if (alpha3Clicked && isPLayer)
        {
           
            Move3();
        }
        if (alpha4Clicked && isPLayer)
        {
            Move4();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            alpha1Clicked = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            alpha2Clicked = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            alpha3Clicked = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            alpha4Clicked = true;
        }
        else if(isPLayer)
        {

            if (Input.GetKey(KeyCode.A))
            {
                transform.position += Vector3.left * Time.deltaTime * speed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += Vector3.down * Time.deltaTime * speed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.right * Time.deltaTime * speed;
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += Vector3.up * Time.deltaTime * speed;
            }
        }

        if (Input.anyKeyDown && isPLayer)
        {
            cheatCode += Input.inputString.ToLower();
            CheckCheatCode();
        }

    }

    IEnumerator GhostToggler()
    {
        yield return new WaitForSeconds(1f);
        transform.gameObject.GetComponent<Renderer>().enabled = !transform.gameObject.GetComponent<Renderer>().enabled;
        yield return StartCoroutine(GhostToggler());
    }

    void CheckCheatCode()
    {
        Debug.Log(cheatCode);
        if (cheatCode.Contains("bigchungus"))
        {
            transform.localScale += transform.localScale;
            cheatCode = string.Empty;
        }
        else if (cheatCode.Contains("hitormiss"))
        {
            StartCoroutine(GhostToggler());
            cheatCode = string.Empty;
        }
        else if (cheatCode.Contains("doyouknowdawae"))
        {
            Camera.main.projectionMatrix = Camera.main.projectionMatrix * Matrix4x4.Scale(new Vector3(1, -1, 1));
            cheatCode = string.Empty;
        }
    }


}
