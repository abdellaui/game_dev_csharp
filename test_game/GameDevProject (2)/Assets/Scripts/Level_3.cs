using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Level_3 : MonoBehaviour
{

    [SerializeField] Text timer = default;
    [SerializeField] Text killCounter = default;
    [SerializeField] GameObject nextLevelScene = default;

    // Start is called before the first frame update
    void Start()
    {
        // MusicManager.instance.Play(1);
        timer.text = 75.ToString();
        GameManager.timer = timer;
        GameManager.killCounter = killCounter;
        GameManager.nextLevelScene = nextLevelScene;
        GameManager.currLvl = 2;
        GameManager.instance.StartTimer();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
