using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aufgabe_5 : MonoBehaviour
{
    bool started = false;
    int tries = 0;
    int rangeStart = 1;
    int rangeEnd = 1001;
    int currentNumber = 0;


    void GoLeftOnRange()
    {

        rangeEnd = currentNumber;
    }


    void GoRightOnRange()
    {
        rangeStart = currentNumber;

    }

    void Teile() {
        currentNumber = rangeStart + (rangeEnd - rangeStart) / 2;
    }
    void RunTurn()
    {
     
        Debug.Log($"Ist deine Zahl {currentNumber} ?");
        Debug.Log("Ja: ENTER/Return;");
        Debug.Log("höher: Pfeil hoch;");
        Debug.Log("tiefer: Pfeil runter;");
    }

    void Restart()
    {
        started = true;
        tries = 0;
        Debug.Log("Denke dir eine Zahl zwischen 1 bis 1000 ein!");
        Debug.Log("Starte mit ENTER/Return!");
        Debug.Log("Gebe mit den Pfeiltasten an ob die Zahl höher oder tiefer ist!");
        Debug.Log("Falls deine Zahl erraten wird bestätige mit ENTER/Return!");
    }

    // Start is called before the first frame update
    void Start()
    {
        Restart();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {

            if (started)
            {

                Debug.Log($"Number: {currentNumber}  |  Tries: {tries} ");
                Restart();
            }
            currentNumber = Random.Range(1, 1000);
            RunTurn();
        }

        if (started)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                GoRightOnRange();
                Teile();
                RunTurn();

            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                GoLeftOnRange();
                Teile();
                RunTurn();
            }
        }



    }
}
