using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] Text text = default;
    bool levelDone = false;

    bool timerIsRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        MusicManager.instance.Play(1, 3.0f);
    }


    IEnumerator Timer()
    {

        yield return new WaitForSeconds(1f);
        int x = int.Parse(text.text);
        x--;
        text.text = x.ToString();
        if (x > 0)
        {
        yield return StartCoroutine(Timer());
        }
        else {
            StopAllCoroutines();
            levelDone = false;
            SceneLoader.instance.LoadScene(0);
        
        }


    }
    // Update is called once per frame
    void Update()
    {
        if (text && !timerIsRunning) {
            timerIsRunning = true;
            StartCoroutine(Timer());
        }

        if (GameObject.FindGameObjectsWithTag("Orb").Length == 0 && !levelDone)
        {
            StopAllCoroutines();
            MusicManager.instance.PlayShot(3);
            MusicManager.instance.StartCoroutine("FadeOut", 7.3f);
            levelDone = !levelDone;
            SceneLoader.instance.LoadNext();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            GameObject[] orbs = GameObject.FindGameObjectsWithTag("Orb");
            foreach(GameObject orb in orbs)
            {
                Destroy(orb);
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            GameObject mainPlanet = GameObject.FindGameObjectWithTag("MainPlanet");
            mainPlanet.GetComponent<EdgeCollider2D>().enabled = !mainPlanet.GetComponent<EdgeCollider2D>().enabled;
        }
    }
}
