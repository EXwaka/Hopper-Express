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
            if (AudioManager.instance.sounds.Length > 0)
            {
                musicSlider.value = AudioManager.instance.sounds[0].source.volume;
            }
        }
        if (sfxSlider != null)
        {
            sfxSlider.onValueChanged.AddListener(SetSFXValue);
            if (AudioManager.instance.sounds.Length > 1)
            {
                sfxSlider.value = AudioManager.instance.sounds[1].source.volume;
            }
        }
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
