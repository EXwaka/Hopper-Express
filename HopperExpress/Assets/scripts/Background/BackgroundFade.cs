using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFade : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public float fadeDuration = 1f; 
    private float currentAlpha = 1f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }


    public IEnumerator FadeOut()
    {
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            currentAlpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            Color newColor = spriteRenderer.color;
            newColor.a = currentAlpha;
            spriteRenderer.color = newColor;

            yield return null;
        }

        Color finalColor = spriteRenderer.color;
        finalColor.a = 0f;
        spriteRenderer.color = finalColor;
    }
    public IEnumerator FadeIn()
    {
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            currentAlpha = Mathf.Lerp(0f, 1f, elapsed / fadeDuration);
            Color newColor = spriteRenderer.color;
            newColor.a = currentAlpha;
            spriteRenderer.color = newColor;

            yield return null;
        }

        Color finalColor = spriteRenderer.color;
        finalColor.a = 1f;
        spriteRenderer.color = finalColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            StartCoroutine(FadeOut());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            StartCoroutine(FadeIn());
        }
    }

}
