using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Aufgabe_2 : MonoBehaviour
{
    enum GameType
    {
        PlayersTurn,
        Sum
    }
    [SerializeField] GameType gametype = GameType.PlayersTurn;
    [SerializeField] Text textGameState = default;
    [SerializeField] Text textStats = default;
    [SerializeField] CubePlayer cubePlayer;
    [SerializeField] CubePlayer AIPlayer = default;



    int wins = 0;
    int loss = 0;
    int draws = 0;


    public void OnWuefelButtonClicked() {
        gametype = GameType.Sum;
    }
    public void OnBehaltenButtonClicked() {
        AIPlayer.OnButtonIsClicked();
        CompareScores();
        cubePlayer.NewRound();
        gametype = GameType.PlayersTurn;
    }

    void CompareScores() {
        int aiScore = AIPlayer.GetScore();
        int playerScore = cubePlayer.GetScore();
        Debug.Log(aiScore);
        Debug.Log(playerScore);
        if (aiScore == playerScore) {
            draws++;
       }else if (aiScore > playerScore) {
            loss++;
        }
        else {
            wins++;
        }
    }

    void ShowStats() {
        textStats.text = $"{wins}/{loss}/{draws}";
    }

    void RefreshTextByType()
    {
        string outp = default;
        switch (gametype)
        {
            case GameType.PlayersTurn:
                outp = "Spieler ist am Zug!"; break;
            case GameType.Sum:
                outp = cubePlayer.GetScore().ToString(); break;

        }

        textGameState.text = outp;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RefreshTextByType();
        ShowStats();
    }
}
