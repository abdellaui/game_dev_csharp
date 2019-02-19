using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] List<AudioClip> musics = default;
    [SerializeField] Slider bgmSoundSlider;
    [SerializeField] AudioMixer audioMixer;
    AudioSource player = default;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<AudioSource>();
    }
    public void OnSliderChangeValue()
    {

        audioMixer.SetFloat("masterVolSoundFX", bgmSoundSlider.value*100-80);
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
