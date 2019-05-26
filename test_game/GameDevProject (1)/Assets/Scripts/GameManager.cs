using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public bool PlayerDead { get; set; } = false;
    public static Text timer = default;
    public static Text killCounter = default;
    [SerializeField] GameObject nextLevelScene = null;

    private string text = "Kills to Win:  ";

    public int[] killsToWin = { 0, 8, 8, 10 };
    private int kills = 0;
    private int killsLeft;
    public int currLvl = 0;

    bool timerEnds = false;
    bool timerIsRunning = false;
    bool gameOver = false;
    bool isPlaying = false;

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
        timer = GameObject.FindWithTag("Timer").GetComponent<Text>();
        killCounter = GameObject.FindWithTag("Counter").GetComponent<Text>();
        Debug.Log(timer);
    }

    void Update()
    {
        Debug.Log(timer.text);
        if (!gameOver && !PlayerDead && currLvl > 0)
        {
            if (timer && !timerIsRunning)
            {
                timerIsRunning = !timerIsRunning;
                StartCoroutine(Timer());
            }

            if (timerEnds && killsLeft > 0)
            {
                timerEnds = false;
                gameOver = true;
                SceneLoader.instance.LoadScene("GameOver");
            }

            if (killsLeft == 0)
            {
                StopAllCoroutines();
                currLvl++;
                StartCoroutine(LevelDone());
            }
        }

        if(!isPlaying && SceneLoader.instance.BuildIndex() > 1)
        {
            isPlaying = !isPlaying;
            NewLevel();
        }

    }

    IEnumerator LevelDone()
    {
        if(nextLevelScene != null)
        {
            nextLevelScene.gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(1f);
        if (currLvl > 3)
        {
            SceneLoader.instance.LoadScene("Win");
        }
        else
        {
            SceneLoader.instance.LoadScene(currLvl);
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
            StopAllCoroutines();
            timerEnds = true;
        }

    }

    public void Kill()
    {
        kills++;
        killsLeft = killsToWin[currLvl] - kills;
        UpdateKillText();
    }

    public void UpdateKillText()
    {
        if (killCounter != null)
        {   
            killCounter.text = text + killsLeft.ToString();
        }
    }

    public void NewLevel()
    {
        StopAllCoroutines();

        timer = GameObject.FindWithTag("Timer").GetComponent<Text>();
        killCounter = GameObject.FindWithTag("Counter").GetComponent<Text>();

        if(currLvl < 3)
            nextLevelScene = GameObject.FindWithTag("NextScene");

        kills = 0;
        killsLeft = killsToWin[currLvl] - kills;

        PlayerDead = false;
        timerEnds = false;
        timerIsRunning = false;
        gameOver = false;

    }
}