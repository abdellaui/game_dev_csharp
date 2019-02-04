using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aufgabe_3 : MonoBehaviour
{
    int inkrementOnO = 0;
    int inkrementOnK = 0;
    int calcInput = 0;
    string x = "";
    bool CheckAnyKeyIsPresed()
    {
        return Input.anyKeyDown;
    }

    void XorEAndW()
    {
        if (Input.GetKey(KeyCode.E) && !Input.GetKey(KeyCode.W))
        {
            Debug.Log("E pressed!");
        }
        else if (!Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.W))
        {
            Debug.Log("W pressed!");
        }
    }

    void ProccessInput()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            x = "";
        }
        x += Input.inputString.ToString();
    }

    void CountFramesWhilePressingK()
    {
        if (inkrementOnK > 0)
        {
            inkrementOnK++;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Key down");
            inkrementOnK++;
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            Debug.Log($"#frames until k pressed: {inkrementOnK}");
            inkrementOnK = 0;
        }
    }

    void CountPressingSomeIntegers()
    {
        bool pressed = false;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            calcInput += 1;
            pressed = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            calcInput += 2;
            pressed = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            calcInput += 3;
            pressed = true;
        }
        if (pressed)
        {
            Debug.Log($"calcInput: {calcInput}");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log($"O pressed: {--inkrementOnO}!");
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log($"P pressed: {++inkrementOnO}!");
        }


        if (Input.GetKeyUp(KeyCode.J))
        {
            Debug.Log("J up!");
        }

        CheckAnyKeyIsPresed();
        XorEAndW();
        ProccessInput();
        CountFramesWhilePressingK();
        CountPressingSomeIntegers();
    }
}
