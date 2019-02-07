using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aufgabe01 : MonoBehaviour
{
    [SerializeField] Text textView = default;

    float waitTime = 1f;
    float timer = 0f;
    bool clickedC = false;
    bool clickedD = false;
    bool runningD = false;
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
 
    }
    IEnumerator ProcessB()
    {
        yield return new WaitForSeconds(1f);
        textView.text = "Hello World!";
    }

    IEnumerator ProcessC()
    {
        yield return new WaitForSeconds(1f);
        textView.text = "0";
        StartCoroutine(Add2());
    }

    IEnumerator ProccessE() {
        textView.text = "I";
        yield return new WaitForSeconds(2f);
        textView.text = "am";
        yield return new WaitForSeconds(2f);
        textView.text = "Groot";
    }
    IEnumerator Add2()
    {
        yield return new WaitForSeconds(1f);
        int x = int.Parse(textView.text);

        x += 2;
        textView.text = x.ToString();

        yield return StartCoroutine(Add2());


    }

    IEnumerator Add1()
    {
        yield return new WaitForSeconds(1f);
        int x = int.Parse(textView.text);

        x++;
        textView.text = x.ToString();

        yield return StartCoroutine(Add1());

    }

    public void OnClickedA()
    {
        textView.text = "Hi";
    }
    public void OnClickedB()
    {
        StopAllCoroutines();
        StartCoroutine(ProcessB());
    }
    public void OnClickedC()
    {
        clickedC = !clickedC;
        if (clickedC)
        {
            StartCoroutine(ProcessC());
        }
        else
        {
            StopAllCoroutines();
        }

    }
    public void OnClickedD()
    {
        if (!runningD && !clickedD) {
            runningD = true;
            clickedD = true;
            textView.text = "0";
            StartCoroutine(Add1());
        }
        else if (clickedD) {
            clickedD = false;
            StopAllCoroutines();
        } else if(!clickedD) {
            clickedD = true;
            StartCoroutine(Add1());
        }
    }
    public void OnClickedE() {
        StopAllCoroutines();
        StartCoroutine(ProccessE());
    }

}
