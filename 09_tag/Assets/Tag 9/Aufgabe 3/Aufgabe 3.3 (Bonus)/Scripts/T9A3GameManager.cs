using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T9A3GameManager : MonoBehaviour
{
    [SerializeField] GameObject winPanel = default;
    [SerializeField] GameObject spell2 = default;
    [SerializeField] GameObject spell3 = default;
    [SerializeField] GameObject spell4 = default;
    [SerializeField] GameObject spell5 = default;

    [SerializeField] T9A3BossBar bossbar = default;

    bool spell2CDstarted = false;
    bool spell3CDstarted = false;
    bool spell4CDstarted = false;
    bool spell5CDstarted = false;

    float spell2CD = 5f;
    float spell4CD = 10f;
    float spell5CD = 3f;

    bool end = false;
    public int playerNumber = 0;
    public bool healing = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Game End
    public bool GameEnded()
    {
        return end;
    }

    public void CallEndScreen(bool win)
    {
        end = true;
        winPanel.SetActive(true);

        if (win)
            winPanel.GetComponentInChildren<Text>().text = "You defeated the boss! " +
                                                        "Your staff didn't drop once again. Too bad.";
        else
            winPanel.GetComponentInChildren<Text>().text = "You died. It's the healer's fault.";
    }

    // Updatze
    void Update()
    {
        if (playerNumber == 0)
            CallEndScreen(false);

        if(spell2CDstarted)
        {
            spell2CD -= Time.deltaTime;

            if (spell2CD <= 0f)
            {
                spell2CDstarted = false;
                spell2CD = 5f;
                spell2.GetComponent<Image>().color = Color.white;
            }
        }

        if (spell4CDstarted)
        {
            spell4CD -= Time.deltaTime;

            if (spell4CD <= 0f)
            {
                spell4CDstarted = false;
                spell4CD = 5f;
                spell4.GetComponent<Image>().color = Color.white;
            }
        }

        if (spell5CDstarted)
        {
            spell5CD -= Time.deltaTime;

            if (spell5CD <= 0f)
            {
                spell5CDstarted = false;
                spell5CD = 5f;
                spell5.GetComponent<Image>().color = Color.white;
            }
        }

    }

    // =============== HEILUNGEN ===============
    // Spell 2 Cooldown
    public void Spell2Casted(T9A3HPBar goToHeal)
    {
        if (!spell2CDstarted)
        {
            goToHeal.currentHealth = Mathf.Clamp01(goToHeal.currentHealth + 0.3f);
            spell2CDstarted = true;
            spell2.GetComponent<Image>().color = new Color(0.509434f, 0.509434f, 0.509434f, 0.3764706f);
        }
    }

    // Spell 3 Cooldown
    public void Spell3Casted(T9A3HPBar goToHeal)
    {
        if (!spell3CDstarted)
        {
            goToHeal.currentHealth = Mathf.Clamp01(goToHeal.currentHealth + 0.5f);
            spell3CDstarted = true;
            spell3.GetComponent<Image>().color = new Color(0.509434f, 0.509434f, 0.509434f, 0.3764706f);
        }
    }

    // Spell 4 Cooldown
    public void Spell4Casted(T9A3HPBar goToHeal)
    {
        if (!spell4CDstarted)
        {
            goToHeal.currentHealth = 1f;
            spell4CDstarted = true;
            spell4.GetComponent<Image>().color = new Color(0.509434f, 0.509434f, 0.509434f, 0.3764706f);
        }
    }

    // Spell 5 Cooldown
    public void Spell5Casted(T9A3HPBar goToHeal)
    {
        if (!spell5CDstarted)
        {
            goToHeal.currentHealth = Mathf.Clamp01(goToHeal.currentHealth - 0.1f);
            bossbar.currentHealth = Mathf.Clamp01(bossbar.currentHealth - 0.1f);
            spell5CDstarted = true;
            spell5.GetComponent<Image>().color = new Color(0.509434f, 0.509434f, 0.509434f, 0.3764706f);
        }
    }
}
