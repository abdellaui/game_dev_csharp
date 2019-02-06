using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aufgabe_1 : MonoBehaviour
{
    List<int> list = new List<int>();

    int[] CreateRNG()
    {
        int[] a = new int[10];
        for (int i = 0; i < a.Length; i++)
        {
            a[i] = Random.Range(0, 101);

        }
        return a;
    }

    int FindMax(int[] a)
    {
        int max = a[0];
        for (int i = 1; i < a.Length; i++)
        {
            if (a[i] > max)
            {
                max = a[i];
            }

        }
        return max;
    }
    void PrintReverse(int[] a)
    {
        for (int i = a.Length - 1; i >= 0; i--)
        {
            Debug.Log(a[i]);
        }
    }



    List<T> Shuffle<T>(List<T> a)
    {
        for (int i = a.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            T temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
        return a;
    }
    // Start is called before the first frame update
    void Start()
    {
        int[] a = CreateRNG();
        Debug.Log($"Array: {a}");
        Debug.Log($"Max: {FindMax(a)}");
        PrintReverse(a);

        Debug.Log("<color=red>############## LIST #############</color>");

        List<int> b = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        b = Shuffle<int>(b);
        b.Reverse();
        PrintReverse(b.ToArray());

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            list.Add(Random.Range(0, 101));
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            string outp = default;
            foreach (int i in list)
            {
                outp += i.ToString() + " ";
            }
            Debug.Log(outp);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            list.Sort((a, b) => -1 * a.CompareTo(b));
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            if (list.Count > 0)
            {
                int rnd = Random.Range(0, list.Count);
                Debug.Log($"Found at index {rnd} element {list[rnd]}");
                list.RemoveAt(rnd);
            }
            else
            {
                Debug.LogWarning("UUuuu!");
            }
        }

    }
}
