using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class Tutoral : MonoBehaviour
{
    public float topPosY, middlePosY;
    public float tweenDuration;
    public RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("TSlideIn", 5f);
        
    }

    void TSlideIn()
    {
        StartCoroutine(SlideIn());

    }
    IEnumerator SlideIn()
    {
        Debug.Log("SlideIn");

        Time.timeScale = 0.2f;
        yield return new WaitForSecondsRealtime(1f);
 
        Time.timeScale = 0f;
        rectTransform.DOAnchorPosY(middlePosY, tweenDuration).SetUpdate(true);
    }
    public void SlideOut()
    {
        Debug.Log("SlideOut triggered. topPosY: " + topPosY);
        Time.timeScale = 1f;

        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, topPosY);

    }
}
