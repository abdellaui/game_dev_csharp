using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aufgabe_1 : MonoBehaviour
{
    bool a;
    int b;
    int c;
    float d;

    void PrintValues()
    {
        Debug.Log($"a: {a} b: {b} c: {c} d: {d}");
    }

    void Hello(string name)
    {
        Debug.Log($"Hello, {name}!");
    }

    float Add(int a, float b)
    {
        return a + b;
    }

    void SetValues(bool a, int b, int c, float d)
    {
        this.a = a;
        this.b = b;
        this.c = c;
        this.d = d;
    }

    int Triple(int a)
    {
        return a * 3;
    }

    float Triple(float a)
    {
        return a * 3.0f;
    }

    void CalcStuff()
    {
        Debug.Log(b / d);
        Debug.Log(((float)b + c) / d);
        Debug.Log((float)b * b / 3);
    }
    // Start is called before the first frame update
    void Start()
    {
        Hello("World");
        SetValues(false, Triple(1), Triple(2), Add(1, 2.0f));
        PrintValues();
        CalcStuff();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
