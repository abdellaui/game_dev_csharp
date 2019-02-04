using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aufgabe_2 : MonoBehaviour
{
    bool firstCall = false;

    void Compare(int a, int b)
    {
        int big = a > b ? a : b;
        Debug.Log($"Größere Nummer: {big}");
    }

    void CheckEven(int a)
    {
        if (a % 2 == 0)
        {

            Debug.Log("Even");
        }
        else
        {
            Debug.Log("Odd");
        }
    }

    bool CheckRange(int between, int start, int end)
    {
        return (start >= between && between <= end);
    }
    void PrintJaNein()
    {
        if (firstCall)
        {
            firstCall = false;
            Debug.Log("Ja");
        }
        else
        {
            Debug.Log("Nein");
        }
    }
    void PrintString(string repeat, int x)
    {
        for (; x >= 0; x--)
        {
            Debug.Log(repeat);
        }
    }

    void PrintNatural(int x)
    {
        int val = 0;
        for (; x >= 0; x--)
        {
            val += x;
        }
        Debug.Log(x);
    }

    void PrintNumber(int x)
    {
        for (; x >= 0; x--)
        {
            switch (x)
            {
                case 0: Debug.Log("Null"); break;
                case 1: Debug.Log("Eins"); break;
                case 2: Debug.Log("Zwei"); break;
                case 3: Debug.Log("Drei"); break;
                // default: throw new KeyNotFoundException();
                default: Debug.Log("Fehler?"); break;
            }
        }
    }

    int CountChars(string searchtext, char searchelement)
    {
        int count = 0;
        foreach (char c in searchtext.ToLower())
        {
            if (c == searchelement) count++;
        }
        return count;
    }

    // Start is called before the first frame update
    void Start()
    {
        Compare(1, 2);
        CheckEven(1);
        CheckEven(2);
        CheckRange(3, 2, 4);
        CheckRange(1, 2, 4);
        PrintJaNein();
        PrintJaNein();
        PrintString("Hello World", 2);
        PrintNatural(10);
        PrintNumber(10);
        CountChars("hhhaaahhh", 'h');
    }

    // Update is called once per frame
    void Update()
    {

    }
}
