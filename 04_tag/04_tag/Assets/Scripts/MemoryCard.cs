using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MemoryCard : MonoBehaviour
{
    public bool isActive = false;
    public int value = default;

    public void SetValue(int val) {
        value = val;
        Hide();
        transform.GetComponentInChildren<Text>().text = value.ToString();
    }

    public void Show() {
        transform.GetComponentInChildren<Text>().enabled = true;
    }
    public void Hide()
    {
        transform.GetComponentInChildren<Text>().enabled = false;
    }
    public bool IsShown() {
        return transform.GetComponentInChildren<Text>().enabled;
    }
    // Start is called      before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Image>().color = (isActive) ? Color.red : Color.white;
    }
}
