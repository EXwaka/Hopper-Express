using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DialogueAnimation : MonoBehaviour
{
    public float topPosY, middlePosY;
    public float tweenDuration;
    public RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SlideIn()
    {
        rectTransform.DOAnchorPosY(middlePosY, tweenDuration).SetUpdate(true);
    }
    public void SlideOut()
    {
        Time.timeScale = 1f;
        rectTransform.DOAnchorPosY(topPosY, tweenDuration).SetUpdate(true);
    }
}
