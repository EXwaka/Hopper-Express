using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeControl : MonoBehaviour
{
    BackgroundFade backgroundFade;
    // Start is called before the first frame update
    void Start()
    {
        backgroundFade = GetComponent<BackgroundFade>();
        Invoke("fade", 40);
    }
    void fade()
    {
        StartCoroutine(backgroundFade.FadeOut());
    }

}
