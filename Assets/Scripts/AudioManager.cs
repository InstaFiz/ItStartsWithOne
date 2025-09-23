using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip growClip;
    public AudioClip finalGrowClip;

    private void Awake()
    {
        // Only one AudioManager can exist
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Carries between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
