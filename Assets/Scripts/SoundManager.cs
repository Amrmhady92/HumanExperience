using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public List<AudioClip> audioClips;
    public AudioSource audioSource;
    public AudioSource endSource;
    bool end = false;
    int audioIndex = 0;
    public float fadeDuration;
    public float endFade = 3f;
    float startVolume;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = audioClips[audioIndex];
        audioSource.Play();
        startVolume = audioSource.volume;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            endCall(endFade);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(FadeOut(audioSource, fadeDuration));
        }
    }
    public IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        Debug.Log("fading");

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }
        if (!end)
        {
            ChangeClip();
        }
        else {
            audioSource.clip = audioClips[0];
            audioSource.Play();
            StartCoroutine(FadeIn(audioSource, fadeDuration));

        }
    }
    public IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
    {
        Debug.Log("fading In");

        while (audioSource.volume < 1)
        {
            audioSource.volume += startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }    
    }
    void ChangeClip ()
    {
        if (audioIndex < audioClips.Count - 1)
        {
            audioIndex++;
            audioSource.clip = audioClips[audioIndex];

        }
        audioSource.Play();
        StartCoroutine(FadeIn(audioSource, fadeDuration));
    }
    public void endCall (float fadeIn)
    {
        end = true;
        endSource.Play();
        StartCoroutine(FadeIn(endSource, fadeIn));
        StartCoroutine(FadeOut(audioSource, fadeDuration));

    }
}
