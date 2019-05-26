using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;
    private static int maxScene = 1;

    void Awake()
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


    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index % maxScene);
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadNext()
    {
        LoadScene((SceneManager.GetActiveScene().buildIndex + 1 + maxScene) % maxScene);
    }

    public void LoadPrev()
    {
        LoadScene((SceneManager.GetActiveScene().buildIndex - 1 + maxScene) % maxScene);
    }

    public int BuildIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
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
        else if (Input.GetKeyDown(KeyCode.F9))
        {
            LoadPrev();
        }
        else if (Input.GetKeyDown(KeyCode.F10))
        {
            LoadNext();
        }
        else if (Input.GetKeyDown(KeyCode.F11))
        {
            LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
