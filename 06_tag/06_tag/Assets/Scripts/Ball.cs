using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ball : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen = default;
    [SerializeField] Image gameOverlay = default;
    bool isGameover = false;
    bool isPlaying = false;
    void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Collision: " + collision.gameObject.name);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "GameObjectBoden")
        {
            GameOver();
        }
    }

    void GameOver()
    {
        isGameover = true;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameover)
        {
            if (gameOverlay.color.a <= 1.0f)
            {

                gameOverlay.color += new Color(0, 0, 0, 0.05f);
            }
            else
            {
                gameOverScreen.SetActive(true);
                isGameover = false;
            }
        }

        if (Input.GetMouseButton(0) && !isPlaying)
        {
            isPlaying = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(Random.value * 20 - 10, 10);

        }

    }
}
