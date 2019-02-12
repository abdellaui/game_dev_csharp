using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aufgabe01 : MonoBehaviour
{
    [SerializeField] GameObject partikel1 = default;
    [SerializeField] GameObject partikel2 = default;
    [SerializeField] TrailRenderer trail = default;

    [SerializeField] LineRenderer line = default;

    Vector3 GetMouseCoards()
    {
        Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector3(mousePoint.x, mousePoint.y, 0);

    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        trail.transform.position = GetMouseCoards();
        if (Input.GetButtonDown("Jump"))
        {
            var inst = Instantiate(partikel1, GetMouseCoards(), Quaternion.identity);
            Destroy(inst.gameObject, 5f);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            var inst = Instantiate(partikel2, GetMouseCoards(), Quaternion.identity);
            Destroy(inst.gameObject, 5f);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            int lastC = line.positionCount;


            Vector3[] points = new Vector3[lastC + 1];
            line.GetPositions(points);
            points[lastC] = GetMouseCoards();
            line.positionCount = points.Length;
            line.SetPositions(points);
        }
    }
}
