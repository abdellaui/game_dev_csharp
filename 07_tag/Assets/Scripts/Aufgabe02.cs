using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Aufgabe02 : MonoBehaviour
{
    [SerializeField] Text musicMode = default;
    [SerializeField] AudioClip bgm = default;
    [SerializeField] List<AudioClip> musics = default;
    [SerializeField] Slider bgmSoundSlider;


    float maxVol = 1.0f;
    int currentMusicIndex = 0;
    AudioSource player = default;
    bool isPlaying = true;

    void OnSliderChangeValue() {
        maxVol = bgmSoundSlider.value;
        player.volume = maxVol;
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
        StartCoroutine(FadeOut(1.0f));
        player.clip = musics[currentMusicIndex % musics.Count];
        StartCoroutine(FadeIn(1.0f));
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
                StartCoroutine(FadeIn(2.0f));
            }
            else
            {
                musicMode.gameObject.SetActive(true);
                StartCoroutine(FadeOut(2.0f));
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
