using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum State
{
    Bed,
    Home,
    Outside,
    University,
    CIP,
    Ending,
    Dead
}

public class Aufgabe_4 : MonoBehaviour
{

    [SerializeField] Text textStory = default;
    [SerializeField] Text textAuswahl = default;

    bool running = false;
    StoryDatabase stories = new StoryDatabase();
    State State = State.Bed;

    readonly Dictionary<State, int> lookup = new Dictionary<State, int>(){
        {State.Bed, 1},
        {State.Home, 2},
        {State.Outside, 2},
        {State.University, 1},
        {State.CIP, 2},
        {State.Ending, 1},
        {State.Dead, 1}
    };


    void RenderLevel()
    {
        textStory.text = stories.GetStoryText(State);
        textAuswahl.text = stories.GetStoryChoices(State);
    }
    void NextLevel()
    {
        if (State < State.Ending)
        {
            State++;
        }
        else
        {
            State = State.Bed;
        }
        RenderLevel();
    }

    void Die()
    {

        if (State < State.Ending)
        {
            textStory.text = stories.GetStoryDeath(State);
            textAuswahl.text = "";
            State = State.Dead;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!running)
        {
            RenderLevel();
            running = true;
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (State < State.Ending && lookup[State] == 1)
            {
                NextLevel();
            }
            else
            {
                Die();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (State < State.Ending && lookup[State] == 2)
            {
                NextLevel();
            }
            else
            {
                Die();
            }

        }


    }
}
