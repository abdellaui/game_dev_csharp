using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubePlayer : MonoBehaviour
{
    int clicked = 0;
    int score = 0;
    [SerializeField] Text cubevalue1 = default;
    [SerializeField] Text cubevalue2 = default;
    [SerializeField] Button wuerfelnButton = default;
    [SerializeField] Button behaltenButton = default;

    public int GetScore()
    {
        return score;
    }

    int CalcScore(int a, int b)
    {
        if (a == b)
        {
            return 3 * a;
        }
        else if (a % 2 == 0 && b % 2 == 0)
        {
            return a + b + 2;
        }
        else if (a % 2 == 1 && b % 2 == 1)
        {
            return a + b - 2;
        }
        else
        {
            return a + b;
        }
    }

    public void NewRound() {
        clicked = 0;
        score = 0;
        cubevalue1.text = "0";
        cubevalue2.text = "0";
        behaltenButton.interactable = false;
        wuerfelnButton.interactable = true;
    }
    public void OnButtonIsClicked()
    {
        int rnd1 = Random.Range(1, 7);
        int rnd2 = Random.Range(1, 7);
        cubevalue1.text = rnd1.ToString();
        cubevalue2.text = rnd2.ToString();
        score = CalcScore(rnd1, rnd2);

        behaltenButton.interactable = true;

        if (clicked >= 2)
        {
            wuerfelnButton.interactable = false;
        }
        else { 
            clicked++;
        }

    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
