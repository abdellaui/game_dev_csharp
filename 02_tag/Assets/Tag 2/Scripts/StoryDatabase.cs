using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryDatabase : MonoBehaviour
{
    // Gibt den Text für die Story zurück
    public string GetStoryText(State State)
    {
        switch (State)
        {
            case State.Bed:
                return "Der zweite Tag des C#-Praktikums ist gekommen. Mit aller Mühe suchst du den Wecker, der schon seit einer " +
                    "gefühlten Ewigkeit klingelt.";
            case State.Home:
                return "Du schaltest den Wecker aus. Als du einen Blick auf die Uhr wirfst, ist jede Müdigkeit wie verflogen. " +
                    "Es ist bereits 15 Uhr.";
            case State.Outside:
                return "Es herrscht eine eisige Kälte, aber dein eiserner Wille trägt dich voran. Stück für Stück kommst du der " +
                    "Uni näher.";
            case State.University:
                return "Du erreichst die Uni, doch - trotz einwandfreier Parkplatzsituation komplett ohne gesperrte Parkhäuser und " +
                    "im Weg stehenden LKWs - findest du keinen Parkplatz.";
            case State.CIP:
                return "Rasend wie der Wind rennst du durch das ID und reißt die Tür zur Bibliothek auf. Du stürmst die Treppen hoch und " +
                    "stehst vor der Tür zur CIP-Insel.";
            case State.Ending:
                return "Du öffnest die Tür und... \"Hallo? Schläfst du?\" Du wachst im CIP-Pool auf und bemerkst, wie der Betreuer vor " +
                    "dir steht. Du bist während der letzten Aufgabe eingeschlafen. Gut.";
            default:
                return "";
        }
    }

    // Gibt den Text für die Auswahlmöglichkeiten zurück
    public string GetStoryChoices(State State)
    {
        switch (State)
        {
            case State.Bed:
                return "(1) Behutsam den Wecker suchen\n(2) Mit voller Wucht um dich schlagen";
            case State.Home:
                return "(1) Aus dem Fenster springen\n(2) Schnell zur Uni fahren";
            case State.Outside:
                return "(1) Schneller fahren\n(2) Eile mit Weile";
            case State.University:
                return "(1) Im Halteverbot parken\n(2) Einfach wieder nach Hause";
            case State.CIP:
                return "(1) Doch keine Lust\n(2) Reingehen";
            case State.Ending:
            case State.Dead:
                return "(1) Neues Spiel";
            default:
                return "";
        }
    }

    // Gibt den Text für die falschen Entscheidungen zurück
    public string GetStoryDeath(State previousState)
    {
        switch (previousState)
        {
            case State.Bed:
                return "Du schlägst absolut alles kurz und klein. Plötzlich stolperst du und brichst dir die Beine. Das war's wohl.";
            case State.Home:
                return "Du springst aus dem Fenster. Auf dem Weg nach unten bemerkst du, dass das wohl doch keine so gute Idee war.";
            case State.Outside:
                return "Du trittst mit aller Macht auf das Gaspedal. Dummerweise steht an der nächsten Kreuzung die Polizei. Lebenslänglich.";
            case State.University:
                return "Du fährst wieder nach Hause. Es ist schließlich nicht deine Schuld, wenn die Uni keinen Parkplatz für dich freihält.";
            case State.Ending:
                return "Du gehst einfach wieder und machst dir einen schönen Tag. Der Betreuer hat eh nichts drauf.";
            default:
                return "";
        }
    }
}