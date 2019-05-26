using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Level_1 : MonoBehaviour
{

    [SerializeField] Text timer = default;
    [SerializeField] Text killCounter = default;
    [SerializeField] GameObject nextLevelScene = default;

    // Start is called before the first frame update
    void Start()
    {
        MusicManager.instance.Play(1);
        timer.text = 45.ToString();
        GameManager.timer = timer;
        GameManager.killCounter = killCounter;
        GameManager.nextLevelScene = nextLevelScene;
        GameManager.currLvl = 0;
        GameManager.instance.StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
