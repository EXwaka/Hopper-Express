using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textAnimation : MonoBehaviour
{
    public TextMeshProUGUI[] texts;      
    public float animationDuration = 10f; 
    public float delayBetweenTexts = 5f;  
    public float startX = -1500f;         
    public float endX = 1500f;           

    private void Start()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            StartCoroutine(AnimateTextWithDelay(texts[i], i * delayBetweenTexts));
        }
    }

    private IEnumerator AnimateTextWithDelay(TextMeshProUGUI text, float delay)
    {
        yield return new WaitForSeconds(delay); 

        RectTransform rectTransform = text.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(startX, rectTransform.anchoredPosition.y); 

        float elapsedTime = 0f;

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            float currentX = Mathf.Lerp(startX, endX, elapsedTime / animationDuration);
            rectTransform.anchoredPosition = new Vector2(currentX, rectTransform.anchoredPosition.y);
            yield return null;
        }

        rectTransform.anchoredPosition = new Vector2(endX, rectTransform.anchoredPosition.y);
    }
}