using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public static Text timer = default;
    public static Text killCounter = default;
    public static GameObject nextLevelScene = null;
    public static int currLvl = 0;
    public bool isFinished = false;

    string text = "Kills to Win:  ";

    int[] killsToWin = { 6, 8, 10 };
    int kills = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
    }

    void Update()
    {
        if(currLvl < 3)
        {
            RenderKills();
        }
    }

    IEnumerator LevelDone()
    {
        isFinished = true;
        yield return new WaitForSeconds(1.2f);

        if (nextLevelScene != null)
        {
            nextLevelScene.gameObject.SetActive(true);
        }

        yield return new WaitForSeconds(1f);

        if (currLvl > 2)
        {
            StopCoroutine(Timer());
        }
        else
        {
            SceneLoader.instance.LoadNext();
        }
    }


    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);
        int x = int.Parse(timer.text);
        x--;
        timer.text = x.ToString();
        if (x > 0)
        {
            yield return StartCoroutine(Timer());
        }
        else
        {
            GameOver();
        }

    }

    public void GameOver()
    {
        isFinished = true;
        StopAllCoroutines();
        SceneLoader.instance.LoadScene("GameOver");
    }

    public void Kill()
    {
        kills++;
     
    }

    public void RenderKills() {
        int killsLeft = killsToWin[currLvl] - kills;

        if (killCounter != null && !isFinished)
        {
            killCounter.text = text + killsLeft.ToString();
        }

        if (killsLeft <= 0 && !isFinished)
        {
            isFinished = true;
            StopAllCoroutines();
            currLvl++;
            StartCoroutine(LevelDone());
        }
    }


    public void AddTime(int extraTime) {
        timer.text = (int.Parse(timer.text) + extraTime).ToString();
    }
    public void AddKills(int extraKill)
    {
        kills += extraKill;
    }
    public void StartTimer()
    {
        isFinished = false;
        kills = 0;
        StopAllCoroutines();
        StartCoroutine(Timer());

    }
}