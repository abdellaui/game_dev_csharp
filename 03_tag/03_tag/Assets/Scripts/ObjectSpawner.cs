using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject square;
    [SerializeField] GameObject circle;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   // Rechts Klick
        if(Input.GetMouseButtonDown(1))
        {
            Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 mousePosition = new Vector3(mousePoint.x, mousePoint.y, 0);

            Quaternion quaternion = Quaternion.identity;
            if (Input.GetKey(KeyCode.R))
            {
                quaternion = Quaternion.Euler(0,0, Random.Range(0.0f, 360.0f));
            }

            if (Input.GetKey(KeyCode.C))
            {
                circle.gameObject.GetComponent<SpriteRenderer>().color = new Color(Random.value,Random.value,Random.value);
            }
            else
            {
                circle.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }

            Circle[] circles = FindObjectsOfType<Circle>();
    
            Instantiate(circle, mousePosition, quaternion);

            if (circles.Length > 10) {
                Destroy(circles[0].gameObject);
            }

        }

        // Links Klick
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 mousePosition = new Vector3(mousePoint.x, mousePoint.y, 0);

            Quaternion quaternion = Quaternion.identity;
            if (Input.GetKey(KeyCode.R))
            {
                quaternion = Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f));
            }

            if (Input.GetKey(KeyCode.C))
            {
                square.gameObject.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value);
            }
            else {
                square.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }

            Square[] squares = FindObjectsOfType<Square>();
            Instantiate(square, mousePosition, quaternion);

            if (squares.Length > 10)
            {
                Destroy(squares[0].gameObject);
            }
        }



        if (Input.GetKey(KeyCode.C))
        {

        }


    }
}
