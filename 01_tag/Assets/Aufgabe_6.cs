using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aufgabe_6 : MonoBehaviour
{

    int playerValue = 0;
    int aiValue = 0;
    bool usersTurn = false;
    bool userGotsACard = false;
    bool userPassed = false;

    void Restart(string reason)
    {
        Debug.Log($"<color=green>Dealerhand: {aiValue} </color>");
        playerValue = 0;
        aiValue = 0;
        usersTurn = false;
        userGotsACard = false;
        userPassed = false;
        Debug.Log(reason);
        // PrintState();
    }

    int GetCard()
    {
        int x = Random.Range(1, 13); // 1 = ass, 2-10 = 2-10, 11= bube, 12= dame, 13 = könig

        if (x == 1)
        {
            return 11;
        }
        else if (x > 10)
        {
            return 10;
        }
        else
        {
            return x;
        }

    }

    void EvaluateGame()
    {

        if (aiValue > 21)
        {
            Restart("<color=green><b>Win</b></color>");
        }
        else if (playerValue > 21)
        {
            Restart("<color=red><b>Loss</b></color>");
        }
        else if (playerValue == 21)
        {
            Restart("<color=green><b>Win</b></color>");
        }
        else if (playerValue == aiValue && userGotsACard)
        {

            Restart("<color=yellow><b>Draw</b></color>");
        }
        else if (aiValue > playerValue && userPassed)
        {
            Restart("<color=red><b>Loss</b></color>");
        }
        else if (aiValue < playerValue && userPassed)
        {
            Restart("<color=green><b>Win</b></color>");
        }

    }

    void PrintState()
    {
        Debug.Log($"<color=yellow>Deine Hand: {playerValue}</color>");
    }
    void PrintRules()
    {
        Debug.Log("Ziehe mit Space eine neue Karte!");

        Debug.Log("Passe mit ENTER/Return!");
        PrintState();

    }

    void ProccessUserInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerValue += GetCard();
            usersTurn = false;
            userGotsACard = true;

  
        }
        else if (userGotsACard && Input.GetKeyDown(KeyCode.Return))
        {
            while (aiValue <= 17)
            {
                aiValue += GetCard();
            }
            usersTurn = false;
            userPassed = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProccessUserInput();

        if (!usersTurn)
        {
            usersTurn = true;



            PrintRules();
            EvaluateGame();


        }
    }
}
