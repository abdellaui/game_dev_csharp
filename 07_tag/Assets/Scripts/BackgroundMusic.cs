using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] List<AudioClip> musics = default;
    [SerializeField] Slider bgmSoundSlider;
    AudioSource player = default;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<AudioSource>();
    }
    void OnSliderChangeValue()
    {
   
        player.volume = bgmSoundSlider.value;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            player.PlayOneShot(musics[Random.Range(0, musics.Count)]);
        }
    }
}
