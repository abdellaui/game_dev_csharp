using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{

    private int maxScene = 1;
    void LoadScene(int index)
    {

        SceneManager.LoadScene(index);
    }

    void LoadNext()
    {
        LoadScene((SceneManager.GetActiveScene().buildIndex + 1 + maxScene) % maxScene);
    }

    void LoadPrev()
    {
        LoadScene((SceneManager.GetActiveScene().buildIndex - 1 + maxScene) % maxScene);
    }
    // Start is called before the first frame update
    void Start()
    {
        maxScene = SceneManager.sceneCountInBuildSettings;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            LoadScene(0);
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            LoadScene(1);
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            LoadScene(2);
        }
        else if (Input.GetKeyDown(KeyCode.F4))
        {
            LoadScene(3);
        }
        else if (Input.GetKeyDown(KeyCode.F5))
        {
            LoadScene(4);
        }
        else if (Input.GetKeyDown(KeyCode.F6))
        {
            LoadScene(5);
        }
        else if (Input.GetKeyDown(KeyCode.F7))
        {
            LoadScene(6);
        }
        else if (Input.GetKeyDown(KeyCode.F8))
        {
            LoadScene(7);
        }
        else if (Input.GetKeyDown(KeyCode.F10))
        {
            LoadNext();
        }
        else if (Input.GetKeyDown(KeyCode.F9))
        {
            LoadPrev();
        }

    }
}
