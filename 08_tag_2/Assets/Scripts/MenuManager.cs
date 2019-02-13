using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

   public void OnButtonStartIsClicked() {
        MusicManager.instance.Stop(3.0f);
        MusicManager.instance.PlayShot(5);
        SceneLoader.instance.LoadScene(1);
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
