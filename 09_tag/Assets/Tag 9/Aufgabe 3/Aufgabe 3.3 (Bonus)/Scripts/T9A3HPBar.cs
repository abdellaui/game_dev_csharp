using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T9A3HPBar : MonoBehaviour
{
    public static GameObject selected;
    T9A3GameManager manager;
    T9A3Spellbar spellbar;
    Image healthbar;
    GameObject selection;
    T9A3HPBar[] allBars;

    bool dead = false;

    [SerializeField] float drainSpeed = 5f;
    public float currentHealth = 1f;

    // Init
    private void Awake()
    {
        healthbar = transform.GetChild(2).GetComponent<Image>();
        selected = transform.GetChild(0).gameObject;
    }

    private void Start()
    {
        allBars = FindObjectsOfType<T9A3HPBar>();
        manager = FindObjectOfType<T9A3GameManager>();
        manager.playerNumber = allBars.Length;
        spellbar = FindObjectOfType<T9A3Spellbar>();

        InvokeRepeating("BurstDamage", 5f, 5f);
    }

    // Update
    void Update()
    {
        if (!manager.GameEnded())
        {
            // Kontinuierlicher Schaden
            currentHealth -= Mathf.Clamp01((Time.deltaTime / drainSpeed)) / manager.playerNumber;
            // UI aktualisieren
            healthbar.fillAmount = currentHealth;

            // Tod abfragen
            if (currentHealth <= Mathf.Epsilon && !dead)
            {
                manager.playerNumber--;
                dead = true;
            }

            CheckHeals();
        }
    }

    // Balken auswählen und alle anderen abwählen
    public void SelectBar()
    {
        if (!dead)
        {
            selected = gameObject;

            foreach (var item in allBars)
                item.transform.GetChild(0).gameObject.SetActive(false);

            selected.transform.GetChild(0).gameObject.SetActive(true);
        }

    }

    // Plötzlicher Schaden alle paar Sekunden
    void BurstDamage()
    {
        if (!dead && !manager.GameEnded())
        {
            if (Random.value < 0.3f)
                currentHealth -= 0.1f;

            if (Random.value < 0.2f)
                currentHealth -= 0.1f;
        }
    }

    // =============== HEILUNGEN ===============
    void CheckHeals()
    {
        // ========== Heilung 1 ========== 
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (selected == gameObject && manager.healing == false)
            {
                manager.healing = true;
                spellbar.ToggleCastHeal();
                Invoke("Heal", 1f);
            }
        }

        // ========== Heilung 2 ========== 
        if (Input.GetKeyDown(KeyCode.Alpha2))
            if (selected == gameObject && manager.healing == false)
                manager.Spell2Casted(this);

        // ========== Heilung 3 ========== 
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (selected == gameObject && manager.healing == false)
            {
                manager.healing = true;
                spellbar.ToggleCastHeal();
                Invoke("Heal3", 0f);
            }
        }

        // ========== Heilung 4 ========== 
        if (Input.GetKeyDown(KeyCode.Alpha4))
            if (selected == gameObject && manager.healing == false)
                manager.Spell4Casted(this);

        // ========== Heilung 5 ========== 
        if (Input.GetKeyDown(KeyCode.Alpha5))
            if (selected == gameObject && manager.healing == false)
                manager.Spell5Casted(this);
    }

    // Normale Heilung
    void Heal()
    {
        currentHealth = Mathf.Clamp01(currentHealth + 0.15f);
        manager.healing = false;
    }

    void Heal3()
    {
        currentHealth = Mathf.Clamp01(currentHealth + 0.4f);
        manager.healing = false;
    }
}
