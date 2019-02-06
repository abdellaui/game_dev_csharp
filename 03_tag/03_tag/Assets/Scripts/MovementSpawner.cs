using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSpawner : MonoBehaviour
{
    [Header("Container")]
    [SerializeField] GameObject containerV1 = default;
    [SerializeField] GameObject containerV2 = default;
    [SerializeField] GameObject containerV3 = default;
    [SerializeField] GameObject containerV4 = default;
    [SerializeField] GameObject containerV5 = default;
    [SerializeField] GameObject containerV6 = default;
    [SerializeField] GameObject containerV7 = default;

    [Space]
    [Header("Prefabs Varianten")]
    [SerializeField] SquareV1 squareV1 = default;
    [SerializeField] SquareV2 squareV2 = default;
    [SerializeField] SquareV3 squareV3 = default;
    [SerializeField] SquareV4 squareV4 = default;
    [SerializeField] SquareV5 squareV5 = default;
    [SerializeField] SquareV6 squareV6 = default;
    [SerializeField] SquareV7 squareV7 = default;

    [Tooltip("Amplitutde bro")] [SerializeField] float amplitute = 1.0f;
    void DeleteAll()
    {
        foreach (SquareV1 sq in FindObjectsOfType<SquareV1>()) {
            Destroy(sq.gameObject);
        }
        foreach (SquareV2 sq in FindObjectsOfType<SquareV2>())
        {
            Destroy(sq.gameObject);
        }
        foreach (SquareV3 sq in FindObjectsOfType<SquareV3>())
        {
            Destroy(sq.gameObject);
        }
        foreach (SquareV4 sq in FindObjectsOfType<SquareV4>())
        {
            Destroy(sq.gameObject);
        }
        foreach (SquareV5 sq in FindObjectsOfType<SquareV5>())
        {
            Destroy(sq.gameObject);
        }
        foreach (SquareV6 sq in FindObjectsOfType<SquareV6>())
        {
            Destroy(sq.gameObject);
        }
        foreach (SquareV7 sq in FindObjectsOfType<SquareV7>())
        {
            Destroy(sq.gameObject);
        }
    }

    void GenerateV1()
    {
        Instantiate(squareV1, Vector3.zero, Quaternion.identity).transform.parent = containerV1.transform;

    }
    void GenerateV2()
    {
        Instantiate(squareV2, Vector3.zero, Quaternion.identity).transform.parent = containerV2.transform;
    }
    void GenerateV3()
    {
        Instantiate(squareV3, Vector3.zero, Quaternion.identity).transform.parent = containerV3.transform;
    }
    void GenerateV4()
    {
        SquareV4 sq = Instantiate(squareV4, Vector3.zero, Quaternion.identity);
        sq.transform.parent = containerV4.transform;
        sq.amplitute = amplitute;
    }
    void GenerateV5()
    {
        Instantiate(squareV5, Vector3.zero, Quaternion.identity).transform.parent = containerV5.transform;
    }
    void GenerateV6()
    {
        Instantiate(squareV6, Vector3.zero, Quaternion.identity).transform.parent = containerV6.transform;
    }
    void GenerateV7()
    {
        Instantiate(squareV7, Vector3.zero, Quaternion.identity).transform.parent = containerV7.transform;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {

            DeleteAll();

        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            GenerateV1();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GenerateV2();

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {

            GenerateV3();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {

            GenerateV4();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            GenerateV5();

        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            GenerateV6();

        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            GenerateV7();

        }

    }
}
