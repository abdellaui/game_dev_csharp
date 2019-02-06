using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum NewState
{
    Bed,
    Bath,
    Talk,
    Ending,
    Dead
}

public class Aufgabe_4_1 : MonoBehaviour
{
    [SerializeField] Text textTitle = default;
    [SerializeField] Text textStory = default;
    [SerializeField] Text textAuswahl = default;

    bool running = false;
    OurStoryDatabase stories = new OurStoryDatabase();
    NewState state = NewState.Bed;

    readonly Dictionary<NewState, int> lookup = new Dictionary<NewState, int>(){
        {NewState.Bed, 1},
        {NewState.Bath, 1},
        {NewState.Talk, 2},
        {NewState.Ending, 1},
        {NewState.Dead, 1}
    };


    void RenderLevel()
    {
        textStory.text = stories.GetStoryText(state);
        textAuswahl.text = stories.GetStoryChoices(state);
    }
    void NextLevel()
    {
        if (state < NewState.Ending)
        {
            state++;
        }
        else
        {
            state = NewState.Bed;
        }
        RenderLevel();
    }

    void Die()
    {
        
        if (state < NewState.Ending)
        {
            textStory.text = stories.GetStoryDeath(state);
            textAuswahl.text = "";
            state = NewState.Dead;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        textTitle.text = "Scheißdraufmoruk!";
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
            if (state < NewState.Ending && lookup[state] == 1)
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
            if (state < NewState.Ending && lookup[state] == 2)
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
