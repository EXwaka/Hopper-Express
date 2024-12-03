using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            /*DontDestroyOnLoad(gameObject);*/ // don't destroy AudioManager when switching scenes
            InitializeSounds();
            LoadSettings(); 
        }
        else
        {
            Destroy(gameObject);
            InitializeSounds();
        }
        Play("MainMenu");
        Play("LevelMusic");
    }
    void InitializeSounds()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    //void Start()
    //{
    //    Play("MainMenu");
    //    Play("LevelMusic");

    //}

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.Stop();
    }

    public void SetVolume(float volume)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == "MainMenu" || s.name == "LevelMusic")
            {
                s.source.volume = volume;
            }
        }
        SaveSettings();
    }
    public void SetSFX(float volume)
    {
        foreach (Sound s in sounds)
        {
            if (s.name != "MainMenu"&& s.name != "LevelMusic")
            {
                s.source.volume = volume;
            }

        }
        SaveSettings();
    }
    private void SaveSettings()
    {
        foreach (Sound s in sounds)
        {
            PlayerPrefs.SetFloat(s.name + "_Volume", s.source.volume);
            PlayerPrefs.SetFloat(s.name + "_Pitch", s.source.pitch);
        }
        PlayerPrefs.Save(); 
    }

    private void LoadSettings()
    {
        foreach (Sound s in sounds)
        {
            if (PlayerPrefs.HasKey(s.name + "_Volume"))
            {
                s.source.volume = PlayerPrefs.GetFloat(s.name + "_Volume");
            }
            if (PlayerPrefs.HasKey(s.name + "_Pitch"))
            {
                s.source.pitch = PlayerPrefs.GetFloat(s.name + "_Pitch");
            }
        }
    }
}
