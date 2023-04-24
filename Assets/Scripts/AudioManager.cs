using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField]
    Sound[] musicaFondo;

    [SerializeField]
    Sound[] sonidos;

    AudioSource musicaFondoS;
    AudioSource sonidoS;
    protected override void Awake()
    {
        base.Awake();

        musicaFondoS = gameObject.AddComponent<AudioSource>();
        sonidoS = gameObject.AddComponent<AudioSource>();
    }

    void Start()
    {
        PlayMusic("Theme");
    }

    Sound FindSound(string name, Sound[] sounds)
    {
        return Array.Find(sounds, s => s.name == name);
    }

    public void PlayMusic(string name)
    {
        Sound sound = FindSound(name, musicaFondo);

        if (sound != null)
        {
            musicaFondoS.loop = true;
            musicaFondoS.clip = sound.clip;
            musicaFondoS.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound sound = FindSound(name, sonidos);

        if (sound != null)
        {
            sonidoS.PlayOneShot(sound.clip);
        }
    }

    public void ToggleMusic()
    {
        musicaFondoS.mute = !musicaFondoS.mute;
    }

    public void ToggleSFX()
    {
        sonidoS.mute = !sonidoS.mute;
    }

    public void SetVolumen(float value)
    {
        musicaFondoS.volume = value;
    }

    public void SetVolumenSFX(float value)
    {
        sonidoS.volume = value;
    }
}
