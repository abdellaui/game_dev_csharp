using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class Aufgabe02 : MonoBehaviour
{
    [SerializeField] Text musicMode = default;
    [SerializeField] AudioClip bgm = default;
    [SerializeField] List<AudioClip> musics = default;
    [SerializeField] Slider bgmSoundSlider;
    [SerializeField] AudioMixer audioMixer;


    float maxVol = 1.0f;
    int currentMusicIndex = 0;
    AudioSource player = default;
    bool isPlaying = true;

    public void OnSliderChangeValue() {
        maxVol = bgmSoundSlider.value;
        audioMixer.SetFloat("masterVolBGM", maxVol*100-80);
    }
    IEnumerator FadeOut(float time)
    {

        while (player.volume > 0)
        {
            player.volume -= 1f * Time.deltaTime / time;
            yield return null;
        }
        player.Stop();
    }

    IEnumerator FadeIn(float time)
    {
        player.Play();
        while (player.volume < maxVol)
        {
            player.volume += 1f * Time.deltaTime / time;
            yield return null;
        }
    }

    void Awake()
    {
        player = GetComponent<AudioSource>();
        player.clip = bgm;
        player.Play();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    void Next()
    {
        currentMusicIndex = (currentMusicIndex + 1 + musics.Count) % musics.Count;
        PlayIndex();
    }

    void Prev()
    {
        currentMusicIndex = (currentMusicIndex - 1 + musics.Count) % musics.Count;
        PlayIndex();
    }
    void PlayIndex()
    {
        StopAllCoroutines();
        StartCoroutine(FadeOut(3.0f));
        player.clip = musics[currentMusicIndex % musics.Count];
        StartCoroutine(FadeIn(3.0f));
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            StopAllCoroutines();
            isPlaying = !isPlaying;
            if (isPlaying)
            {
                musicMode.gameObject.SetActive(false);
                StartCoroutine(FadeIn(3.0f));
            }
            else
            {
                musicMode.gameObject.SetActive(true);
                StartCoroutine(FadeOut(3.0f));
            }
        }

        if (Input.GetKeyDown(KeyCode.A) && isPlaying)
        {
            Next();
        }

        if (Input.GetKeyDown(KeyCode.D) && isPlaying)
        {
            Prev();
        }
 
    }
}
