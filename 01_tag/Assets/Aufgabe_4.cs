using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aufgabe_4 : MonoBehaviour
{
    int rememberByR = 0;
    float chanceByT = 0.05f;
    int sumByZ = 0;
    void ListenOnQPress()
    {
        if (Input.GetKeyDown(KeyCode.Q))

        {
            Debug.Log($"Q Pressed: {Random.Range(-3.0f, 6.0f)}");
        }

    }

    void ListenOnWPress()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log($"Q Pressed: {Random.value * 9.0f - 3.0f}");
        }
    }

    void ListenOnEPress()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            string output = "Failed";
            if (Random.value <= 0.5f)
            {
                output = Random.Range(1, 11).ToString();
            }
            Debug.Log($"Q Pressed: {output}");
        }
    }

    void ListenOnRPress()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            int currRandomValue = 0;

            do
            {
                currRandomValue = Random.Range(1, 11);
            }
            while (rememberByR == currRandomValue);

            rememberByR = currRandomValue;

            Debug.Log($"R Pressed: {rememberByR}");
        }
    }


    void ListenOnTPress()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            string output = "Failed";
            if (Random.value >= chanceByT)
            {
                chanceByT += 0.05f;
            }
            else
            {
                chanceByT = 0.05f;
                output = "Success";
            }

            Debug.Log($"T Pressed: {output}");
        }
    }

    void ListenOnZPress() {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            float currentRandomValue = Random.value;
            if (currentRandomValue <= 0.3f)
            {
                sumByZ += 1;
            }
            else if(currentRandomValue <= 0.7f) // 30% + 40%
            {
                sumByZ += 2;
            }
            else if (currentRandomValue <= 0.9f) // 70% + 20%
            { 
                sumByZ += 3;
            }
            else
            {
                sumByZ += 4;
            }

            Debug.Log($"Z Pressed: {sumByZ}");
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ListenOnQPress();
        ListenOnWPress();
        ListenOnEPress();
        ListenOnRPress();
        ListenOnTPress();
        ListenOnZPress();

    }
}
