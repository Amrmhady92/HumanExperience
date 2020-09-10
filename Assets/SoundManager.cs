using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public List<AudioClip> audioClips;
    public AudioSource audioSource;
    int audioIndex = 0;
    public float fadeDuration;
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
        ChangeClip();
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
}
