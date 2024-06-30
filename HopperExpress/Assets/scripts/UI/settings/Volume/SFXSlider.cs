using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SFXSlider : MonoBehaviour
{
    [SerializeField] private Slider SFXslider;

    void Start()
    {
        if (SFXslider != null)
        {
            SFXslider.onValueChanged.AddListener(SetSFXValue);
            SFXslider.value = AudioManager.instance.sounds[0].source.volume;
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
