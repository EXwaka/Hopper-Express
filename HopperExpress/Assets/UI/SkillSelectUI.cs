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
        Debug.Log("TimeScale" + Time.timeScale);
        if (Timer.timeLeft <= 1 && Wavespawner.monsCount <= 0)
        {
            SkillMenu.SetActive(true);
            StartCoroutine(SlideIn());
        }

        else if (okButton == false)
        {
            Time.timeScale = 1f; 
        }

    }

    IEnumerator SlideIn()
    {
        Time.timeScale = 0.2f;
        yield return new WaitForSeconds(0.3f);
        Time.timeScale = 1f;

        rectTransform.DOAnchorPosY(middlePosY, tweenDuration);
    }


    public void SlideOut()
    {

        SceneController.instance.NextLevel();


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
