using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class SkillSelectUI : MonoBehaviour
{
    public GameObject SkillMenu;

    public RectTransform rectTransform;
    public float topPosY, middlePosY;
    public float tweenDuration;
    public bool okButton=false;
    public GameObject NextButton;

    // Start is called before the first frame update
    void Start()
    {
        SkillMenu.SetActive(false);
        okButton = false;
        NextButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(FinishPoint.LevelComplete==true && okButton==false)
        {
            SkillMenu.SetActive(true);
            SlideIn();
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        if(okButton==true)
        {

        }
    }

    public void SlideIn()
    {
        rectTransform.DOAnchorPosY(middlePosY, tweenDuration).SetUpdate(true);


    }
    public void SlideOut()
    {
        //okButton = true;
        //rectTransform.DOAnchorPosY(topPosY, tweenDuration).SetUpdate(true);
        //Time.timeScale = 1f;
        SceneController.instance.NextLevel();
        FinishPoint.LevelComplete = false;


    }

    public void ChooseSkill1()
    {
        Skills.skill_forcefield = true;
        Skills.skill_throwfire = false;
        Skills.skill_floorspike = false;
        //Debug.Log(Skills.skill_forcefield);
        NextButton.SetActive(true);

    }
    public void ChooseSkill2()
    {
        Skills.skill_forcefield = false;
        Skills.skill_throwfire = true;
        Skills.skill_floorspike = false;
        NextButton.SetActive(true);


    }
    public void ChooseSkill3()
    {
        Skills.skill_forcefield = false;
        Skills.skill_throwfire = false;
        Skills.skill_floorspike = true;
        NextButton.SetActive(true);

    }

}
