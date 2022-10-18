using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using Unity.VisualScripting;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] ambientSounds, sfxSounds;
    public AudioSource ambientSource, sfxSource;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {

    }

    public void PlayMusic(string Name)
    {
        Sound s = Array.Find(ambientSounds, x => x.Name == Name);


        if (s == null)
        {
            Debug.Log("Sound not found");
        }

        else
        {
            ambientSource.clip = s.clip;
            ambientSource.Play();
        }

    }

    public void PlaySFX(string Name)
    {
        Sound s = Array.Find(sfxSounds, x => x.Name == Name);

        if (s == null)
        {
            Debug.Log("Sound not found");
        }

        else
        {
            sfxSource.clip = s.clip;
            sfxSource.Play();
        }
    }

}
