using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class textFade : MonoBehaviour
{
        public float delayBeforeFadeIn = 2f;
        private float fadeInDuration = 1f;   
        public float delayBeforeFadeOut = 2f;
        private float fadeOutDuration = 1f; 
        private Text textComponent; 

        private void Start()
        {
            textComponent = GetComponent<Text>(); 
            textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, 0f);
            StartCoroutine(FadeInAndOutText());
        }

        private IEnumerator FadeInAndOutText()
        {
            yield return new WaitForSeconds(delayBeforeFadeIn);
            yield return FadeIn();

            yield return new WaitForSeconds(delayBeforeFadeOut);
            yield return FadeOut();
        }

        private IEnumerator FadeIn()
        {
            Color originalColor = textComponent.color; 
            textComponent.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f); 

            float elapsedTime = 0f;
            while (elapsedTime < fadeInDuration)
            {
                elapsedTime += Time.deltaTime;
                float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInDuration);
                textComponent.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
                yield return null; 
            }

            textComponent.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f);
        }

        private IEnumerator FadeOut()
        {
            float elapsedTime = 0f;
            Color originalColor = textComponent.color;

            while (elapsedTime < fadeOutDuration)
            {
                elapsedTime += Time.deltaTime;
                float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeOutDuration);
                textComponent.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
                yield return null;
            }

            textComponent.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
            textComponent.gameObject.SetActive(false);
        }
}
