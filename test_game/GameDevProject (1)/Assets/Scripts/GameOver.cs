using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void OnPlayAgain()
    {
        SceneLoader.instance.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
