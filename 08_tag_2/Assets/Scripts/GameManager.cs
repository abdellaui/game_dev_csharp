using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool levelDone = false;
    // Start is called before the first frame update
    void Start()
    {
        MusicManager.instance.Play(1, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Orb").Length == 0 && !levelDone)
        {
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
