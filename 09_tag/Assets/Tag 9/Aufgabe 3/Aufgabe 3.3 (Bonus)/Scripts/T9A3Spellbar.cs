using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T9A3Spellbar : MonoBehaviour
{
    T9A3GameManager manager;
    Image castbar;

    bool castHeal = false;

    private void Awake()
    {
        castbar = transform.GetChild(1).GetComponent<Image>();
    }

    private void Start()
    {
        manager = FindObjectOfType<T9A3GameManager>();
    }

    void Update()
    {
        // Heilung wurde gecasted
        if (castHeal)
        {
            castbar.fillAmount += Time.deltaTime;

            if (castbar.fillAmount >= 1f)
            {
                castbar.fillAmount = 0f;
                castHeal = false;
            }        
        }
    }

    public void ToggleCastHeal()
    {
        castHeal = !castHeal;
    }

}
