using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OurStoryDatabase : MonoBehaviour
{
    // Gibt den Text für die Story zurück
    public string GetStoryText(NewState State)
    {
        switch (State)
        {
            case NewState.Bed:
                return "Du bist am Ende deines Studium. Ein Vorstellungsgespräch steht an! Du musst aufstehen, dein Wecker klingelt schon!";
            case NewState.Bath:
                return "Du hast es eilig und bist unvorbereitet! Du musst schnell los!";
            case NewState.Talk:
                return "Dein Arbeitgeber fragt nach deinen Schwächen!";
            case NewState.Ending:
                return "Herzlichen Glückwunsch! Du bist bereit für dein Karrierlaufbahn!";
            default:
                return "";
        }
    }

    // Gibt den Text für die Auswahlmöglichkeiten zurück
    public string GetStoryChoices(NewState State)
    {
        switch (State)
        {
            case NewState.Bed:
                return "(1) Aufstehen, Wecker ausmachen und anziehen!\n(2) Wecker weg drücken und weiter pennenn";
            case NewState.Bath:
                return "(1) Duschen, Zähne putzen & Haare stylen\n(2) Gesicht waschen und direkt zum Vorstellungsgespräch!";
            case NewState.Talk:
                return "(1) Seine ganzen Schwächen aufzählen!\n(2) Die Schwächen positiv verkaufen!";
            case NewState.Ending:
            case NewState.Dead:
                return "(1) Neues Spiel";
            default:
                return "";
        }
    }

    // Gibt den Text für die falschen Entscheidungen zurück
    public string GetStoryDeath(NewState previousState)
    {
        switch (previousState)
        {
            case NewState.Bed:
                return "Du hast dein Vorstellungsgespräch verpasst. Du endest im Arbeitsamt!";
            case NewState.Bath:
                return "Du stinkst, dein zukünftiger Arbeitsgeber gibt dir nicht die Hand!";
            case NewState.Talk:
                return "Du wirst ausgelacht und nicht als eignungsfähig angesehen!";
            case NewState.Ending:
                return "Hey! Dein Vorstellungsgespräch lief super! Du wurdest eingestellt!";
            default:
                return "";
        }
    }
}