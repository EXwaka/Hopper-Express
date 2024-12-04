using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class TalkTriggerSkill : MonoBehaviour
{
    public GameObject Ebutton;
    public RectTransform rectTransform;
    public float topPosY, middlePosY;
    public float tweenDuration;

    // Start is called before the first frame update
    void Start()
    {
        Ebutton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&Ebutton)
        {
            CharacterMove.ableToMove = false;
            SlideIn();
        }

    }
    void SlideIn()
    {
        rectTransform.DOAnchorPosY(middlePosY, tweenDuration).SetUpdate(true);
    }
    void SlideOut()
    {
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, topPosY);
    }

    public void confirm()
    {
        CharacterMove.ableToMove=true;
        SlideOut();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            Ebutton.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            Ebutton.SetActive(false);
        }
    }
}
