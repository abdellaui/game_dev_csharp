using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BreakoutManager : MonoBehaviour
{
    [SerializeField] List<Block> blocks = default;
    [SerializeField] int currentLevel = 0;

    public void OnPlayAgainClicked() {
        currentLevel = 0;
        Debug.Log("s");
        new SceneLoader().LoadScene(0);
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(currentLevel == 0 && blocks.Count == 0) {
            new SceneLoader().LoadNext();
            currentLevel++;
        }
    }
}
