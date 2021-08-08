using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioSystem : MonoBehaviour
{
    [SerializeField] private Sounds _soundsContainer;
    private static Sound[] _sounds;
    private static AudioSystem _instance;
    private static bool isAudioSourcesInit = false;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        _sounds = _soundsContainer.Sound;

        //if (_instance == null)
        //    _instance = this;
        //else if (_instance != this)
        //    Destroy(gameObject);
    }

    private void Init()
    {
        isAudioSourcesInit = true;

        foreach (Sound sound in _sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.loop = sound.loop;
        }
    }

    public Sound FindSound(SoundKey soundKey)
    {
        if (isAudioSourcesInit == false)
            Init();

        Sound targetSound = Array.Find(_sounds, sounds => sounds.name == soundKey);

        if (targetSound == null)
        {
            Debug.LogError("Sound " + name + " not found");
            return null;
        }
        else
        {
            return targetSound;
        }
    }

    public void Play(SoundKey soundKey)
    {
        Sound targetSound = FindSound(soundKey);
        if (targetSound != null)
            targetSound.source.Play();


    }

    public bool IsPlaying(SoundKey soundKey)
    {
        Sound targetSound = FindSound(soundKey);
        Debug.Log(targetSound.source.isPlaying);
        return targetSound.source.isPlaying;
    }

    public void Stop(SoundKey soundKey)
    {
        Sound targetSound = FindSound(soundKey);
        if (targetSound != null)
            targetSound.source.Stop();
    }


}
