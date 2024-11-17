using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeControl : MonoBehaviour
{
    BackgroundFade backgroundFade;
    public float fadeOutAt=40;
    public float fadeInAt;
    public bool ShouldFadeIn = false;
    public bool ShouldFadeOut = false;
    // Start is called before the first frame update
    void Start()
    {
        backgroundFade = GetComponent<BackgroundFade>();
        if (ShouldFadeOut)
        {
            Invoke("fade", fadeOutAt);

        }
        if(ShouldFadeIn)
        {
            Invoke("fadeIn", fadeInAt);

        }
    }
    void fade()
    {
        StartCoroutine(backgroundFade.FadeOut());
    }
    void fadeIn()
    {
        StartCoroutine(backgroundFade.FadeIn());
    }

}
