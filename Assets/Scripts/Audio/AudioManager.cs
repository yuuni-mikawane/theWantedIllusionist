using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCommon;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : SingletonBindAlive<AudioManager>
{
    [SerializeField] private Sound[] sounds;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Sound sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
        }
    }

    public float CurrentSFXVolume()
    {
        return sounds[4].volume / sounds[4].audioSource.volume;
    }

    public void UpdateSFXVolume(float volume)
    {
        foreach (Sound sound in sounds)
        {
            sound.audioSource.volume = sound.volume * volume;
        }
    }

    public void JumpSFX()
    {
        sounds[0].audioSource.Play();
    }

    public void OrbSFX()
    {
        sounds[1].audioSource.Play();
    }

    public void SlashSFX()
    {
        sounds[2].audioSource.Play();
    }

    public void HurtSFX()
    {
        sounds[3].audioSource.Play();
    }

    public void ExplosionSFX()
    {
        sounds[4].audioSource.Play();
    }
}
