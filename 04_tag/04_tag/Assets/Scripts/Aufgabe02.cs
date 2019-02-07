using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Aufgabe02 : MonoBehaviour
{

    [SerializeField] Slider mainSlider = default;

    public void OnSliderValueChanged()
    {
        Debug.Log(mainSlider.value);
        ChangeGameSpeed(mainSlider.value);
    }

    void ChangeGameSpeed(float speed)
    {
        foreach (Player p in FindObjectsOfType<Player>())
        {
            p.speed = speed * 10;
        }

        foreach (CircleLight c in FindObjectsOfType<CircleLight>())
        {
            c.waitTime = 1-speed;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
