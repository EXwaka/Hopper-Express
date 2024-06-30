using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class VolumSlider : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    void Start()
    {
        if (musicSlider != null)
        {
            musicSlider.onValueChanged.AddListener(SetMusicValue);
            if (AudioManager.instance != null)
            {
                float mainMenuVolume = AudioManager.instance.sounds.FirstOrDefault(s => s.name == "MainMenu")?.source.volume ?? 0f;
                float levelMusicVolume = AudioManager.instance.sounds.FirstOrDefault(s => s.name == "LevelMusic")?.source.volume ?? 0f;
                musicSlider.value = mainMenuVolume > 0 ? mainMenuVolume : levelMusicVolume;
            }
        }
        if (sfxSlider != null)
        {
            sfxSlider.onValueChanged.AddListener(SetSFXValue);
            if (AudioManager.instance != null)
            {
                float SFX1Volume = GetVolumeByName("MonsterDeath");
            }
        }
    }
    private float GetVolumeByName(string name)
    {
        Sound sound = Array.Find(AudioManager.instance.sounds, s => s.name == name);
        if (sound != null)
        {
            return sound.source.volume;
        }
        return 0f;
    }
    public void SetMusicValue(float value)
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SetVolume(value);
        }
    }
    public void SetSFXValue(float value)
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SetSFX(value);
        }
    }
}
