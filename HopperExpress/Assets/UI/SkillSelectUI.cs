using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SkillSelectUI : MonoBehaviour
{
    public GameObject SkillMenu;

    public RectTransform rectTransform;
    public float topPosY, middlePosY;
    public float tweenDuration;
    public bool okButton=false;

    // Start is called before the first frame update
    void Start()
    {
        SkillMenu.SetActive(false);
        okButton = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(CharacterMove.LevelComplete==true && okButton==false)
        {
            SkillMenu.SetActive(true);
            SlideIn();
            Time.timeScale = 0f;
        }
    }

    public void SlideIn()
    {
        rectTransform.DOAnchorPosY(middlePosY, tweenDuration).SetUpdate(true);


    }
    public void SlideOut()
    {
        okButton = true;

        rectTransform.DOAnchorPosY(topPosY, tweenDuration).SetUpdate(true);
        Time.timeScale = 1f;


    }

    public void ChooseSkill1()
    {
        Skills.skill_forcefield = true;
        Skills.skill_throwfire = false;
        Skills.skill_floorspike = false;

    }
    public void ChooseSkill2()
    {
        Skills.skill_forcefield = false;
        Skills.skill_throwfire = true;
        Skills.skill_floorspike = false;
    }
    public void ChooseSkill3()
    {
        Skills.skill_forcefield = false;
        Skills.skill_throwfire = false;
        Skills.skill_floorspike = true;
    }

}
