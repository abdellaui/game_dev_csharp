using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void OnPlayGame()
    {
        StartCoroutine(PlayLevel1());
    }

    public void Quit()
    {
        Application.Quit();
    }

    private IEnumerator PlayLevel1()
    {
        yield return new WaitForSeconds(1.5f);
        SceneLoader.instance.LoadNext();
    }

}
