using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T9A3BossBar : MonoBehaviour
{
    T9A3GameManager manager;
    Image healthbar;
    Text hpText;

    [SerializeField] float drainSpeed = 30f;
   public float currentHealth = 1f;

    private void Awake()
    {
        healthbar = transform.GetChild(1).GetComponent<Image>();
        hpText = transform.GetChild(2).GetComponent<Text>();
    }

    private void Start()
    {
        manager = FindObjectOfType<T9A3GameManager>();
    }

    void Update()
    {
        if (!manager.GameEnded())
        {
            currentHealth -= Mathf.Clamp01(((Time.deltaTime / drainSpeed)) * manager.playerNumber);

            healthbar.fillAmount = currentHealth;
            hpText.text = (currentHealth * 100).ToString("#.00") + "%";

            if (currentHealth <= Mathf.Epsilon)
            {
                hpText.text = "Dead";
                manager.CallEndScreen(true);
            }
        }
    }
}
