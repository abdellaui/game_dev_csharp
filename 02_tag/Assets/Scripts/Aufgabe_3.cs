using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Aufgabe_3 : MonoBehaviour
{
    [SerializeField] Text resultText = default;
    [SerializeField] Text anagramText = default;
    [SerializeField] Text predictText = default;
    string word = default;
    [SerializeField]  string predict = default;

    [SerializeField] List<string> list = default;

    int currRandom = default;

    public void OnCheckClicked()
    {
        if(CheckAnagram(word,predict))
        {
            resultText.color = Color.green;
            resultText.text = "Ja";
        }
        else
        {
            resultText.color = Color.red;
            resultText.text = "Nein";
        }
    }

    public void OnCreateClicked()
    {
        currRandom = Random.Range(0, list.Count);
        word = CreateAnagram(list[currRandom]);
        anagramText.text = word;
    }

    public void OnSolutionClicked()
    {
        predictText.text = list[currRandom];
    }

    string CreateAnagram(string word)
    {
        char[] a = word.ToLower().ToCharArray();
        for (int i = word.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            char temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
        return new string(a);
    }
    bool CheckAnagram(string a, string b)
    {
        string newA = System.String.Concat(a.ToLower().OrderBy(c => c));
        string newB = System.String.Concat(b.ToLower().OrderBy(c => c));

        return newA == newB;
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
