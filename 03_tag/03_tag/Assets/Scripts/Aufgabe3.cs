using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aufgabe3 : MonoBehaviour
{
    [SerializeField] List<GameObject> gameObjects = default;
    [SerializeField] List<Card> cards = default;
    int lastCardIndex = 0;

    List<T> Shuffle<T>(List<T> a)
    {
        for (int i = a.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            T temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
        return a;
    }

    void ShuffleCards()
    {
        cards = Shuffle<Card>(cards);
    }
    // Start is called before the first frame update
    void Start()
    {
        ShuffleCards();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (cards.Count > 0)
            {
                Card lastCard = cards[0];
                cards.RemoveAt(0);
                GameObject g = gameObjects[lastCardIndex++];

                g.SetActive(true);
                g.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = lastCard.spr;
                g.name = lastCard.title;
                cards.Add(lastCard);
            }

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (lastCardIndex >= 0)w
            {
                gameObjects[lastCardIndex--].SetActive(false);
                if (lastCardIndex < 0) { lastCardIndex = 0; }
                ShuffleCards();
            }

        }
    }
}
