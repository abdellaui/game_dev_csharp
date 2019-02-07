using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MemoryManager : MonoBehaviour
{
    [SerializeField] List<MemoryCard> cards = default;
    [SerializeField] Text score1 = default;
    [SerializeField] Text score2 = default;


    List<MemoryCard> openCards = new List<MemoryCard>();

    private bool player1 = true;
    private int player1Scores = 0;
    private int player2Scores = 0;

    private int activeIndex = 0;

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

    void IndexRight()
    {
        cards[activeIndex].isActive = false;
        activeIndex = (activeIndex + 1 + cards.Count) % cards.Count;
        cards[activeIndex].isActive = true;
    }
    void IndexLeft()
    {
        cards[activeIndex].isActive = false;
        activeIndex = (activeIndex - 1 + cards.Count) % cards.Count;
        cards[activeIndex].isActive = true;
    }
    // Start is called before the first frame update
    void ChooseCard()
    {
        if (cards.Count <= 0) {
            return;
        }
        MemoryCard currentCard = cards[activeIndex];
        if (openCards.Count < 2 && !currentCard.IsShown())
        {
            MemoryCard opened = cards[activeIndex];
            opened.Show();
            openCards.Add(opened);

            if (openCards.Count == 2)
            {
                if (openCards[0].value == openCards[1].value)
                {
                    if (player1)
                    {
                        player1Scores++;
                    }
                    else
                    {
                        player2Scores++;
                    }
                    foreach (MemoryCard c in openCards)
                    {
                        MemoryCard found = cards.Find((MemoryCard obj) => obj == c);
                        cards.Remove(found);
                        Destroy(found.gameObject);
                        if (cards.Count > 0) { 
                        activeIndex = (activeIndex + cards.Count) % cards.Count;
                        }
                        else {
                            activeIndex = 0;
                        }
                        Debug.Log(activeIndex);
                    }
                    openCards.Clear();
                }

            }
        }
        else if (openCards.Count == 2)
        {
            foreach (MemoryCard c in openCards)
            {
                c.Hide();
            }
            openCards.Clear();
            player1 = !player1;
        }
    }
    void ShuffleCards()
    {
        List<int> l = new List<int>();
        for (int x = 0; x < cards.Count; x++)
        {
            l.Add((x / 2) + 1);
        }
        //l = Shuffle<int>(l);

        int index = 0;
        foreach (int i in l)
        {
            cards[index++].SetValue(i);
        }
    }

    void Start()
    {


        cards[activeIndex].isActive = true;
        ShuffleCards();
    }
    // Update is called once per frame
    void Update()
    {
        score1.color = (player1) ? Color.green : Color.white;
        score2.color = (!player1) ? Color.green : Color.white;

        if (Input.GetKeyDown(KeyCode.D) && cards.Count > 0)
        {
            IndexRight();
        }

        if (Input.GetKeyDown(KeyCode.A) && cards.Count > 0)
        {
            IndexLeft();
        }
        if (Input.GetKeyDown(KeyCode.Space) && cards.Count>0)
        {
            ChooseCard();
        }

        score1.text = player1Scores.ToString();
        score2.text = player2Scores.ToString();

    }
}
