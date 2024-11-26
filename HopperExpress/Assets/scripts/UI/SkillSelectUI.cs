using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Cinemachine;


public class SkillSelectUI : MonoBehaviour
{
    SkillsList skills;

    public GameObject SkillMenu;

    public RectTransform rectTransform;
    public float topPosY, middlePosY;
    public float tweenDuration;
    public bool okButton=false;
    public GameObject NextButton;
    private CinemachineBrain cinemachineBrain;
    private bool slideIn=false;

    public GameOverControl gameOverControl;

    static public bool Chapter1Done=false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        //SkillMenu.SetActive(false);
        okButton = false;
        NextButton.SetActive(false); 
        slideIn = false;
        cinemachineBrain = FindObjectOfType<CinemachineBrain>();

        skills=GetComponent<SkillsList>();
    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log("TimeScale" + Time.timeScale);

        //Debug.Log($"Timer.timeLeft: {Timer.timeLeft}, Wavespawner.monsCount: {Wavespawner.monsCount}");
        //if(Timer.timeLeft<=0&& Wavespawner.monsCount >= 1)
        //{
        //    StartCoroutine(Fail());
        //}

        if (Timer.timeLeft <= 1 && Wavespawner.monsCount <= 0)
        {
            SkillMenu.SetActive(true);
            if(!slideIn)
            {
                StartCoroutine(SlideIn());
                slideIn = true;
            }
        }
 

    }



    IEnumerator SlideIn()
    {
        Time.timeScale = 0.2f; 
        yield return new WaitForSecondsRealtime(1f);
        if (cinemachineBrain != null)
        {
            cinemachineBrain.enabled = false;
        }
        Time.timeScale = 0f; 
        rectTransform.DOAnchorPosY(middlePosY, tweenDuration).SetUpdate(true);
    }


    public void SlideOut()
    {
        cinemachineBrain.enabled = true;
        Time.timeScale = 1f;

        SkillMenu.SetActive(false);
        okButton = false;
        NextButton.SetActive(false);
        slideIn = false;
        cinemachineBrain = FindObjectOfType<CinemachineBrain>();
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, topPosY);

        //gameObject.TryGetComponent<Timer>(out Timer timer);
        //{
        //    timer.ResetTimer();

        //}

        SceneController.instance.NextLevel();

    }

    IEnumerator Fail()
    {
        Time.timeScale = 0.2f;
        yield return new WaitForSecondsRealtime(1f);
        gameOverControl.SlideIn();
        Time.timeScale = 0;
    }

    public void ChooseSkill1()
    {
        Skills.skill_throwfire = true;
        Skills.skill_throwice = false;
        Skills.skill_throwpoison = false;
        NextButton.SetActive(true);


    }
    public void ChooseSkill2()
    {
        Skills.skill_throwfire = false;
        Skills.skill_throwice = true;
        Skills.skill_throwpoison = false;
        NextButton.SetActive(true);

    }
    public void ChooseSkill3()
    {
        Skills.skill_throwfire = false;
        Skills.skill_throwice = false;
        Skills.skill_throwpoison = true;



    }
    public void ChooseSkill4()
    {
        Skills.skill_forcefield = true;
        Skills.skill_electricfance = false;
        Skills.skill_floorspike = false;
        NextButton.SetActive(true);

        Chapter1Done = true;

    }
    public void ChooseSkill5()
    {

        Skills.skill_forcefield = false;
        Skills.skill_electricfance = true;
        Skills.skill_floorspike = false;
        NextButton.SetActive(true);

        Chapter1Done = true;

    }
    public void ChooseSkill6()
    {
        Skills.skill_forcefield = false;
        Skills.skill_electricfance = false;
        Skills.skill_floorspike = true;
        NextButton.SetActive(true);

        Chapter1Done = true;

    }
    public void ChooseSkill7()
    {
        Skills.skill_player2 = true;
        Skills.skill_jetpack = false;
        Skills.skill_turrets = false;
        NextButton.SetActive(true);
    }
    public void ChooseSkill8()
    {
        Skills.skill_player2 = false;
        Skills.skill_jetpack = true;
        Skills.skill_turrets = false;
        NextButton.SetActive(true);
    }
    public void ChooseSkill9()
    {
        Skills.skill_player2 = false;
        Skills.skill_jetpack = false;
        Skills.skill_turrets = true;
        NextButton.SetActive(true);
    }
    public void ChooseSkill10()
    {
        Skills.skill_airattack = true;
        Skills.skill_automissile = false;
        Skills.skill_berserk = false;
        NextButton.SetActive(true);
    }
    public void ChooseSkill11()
    {
        Skills.skill_airattack = false;
        Skills.skill_automissile = true;
        Skills.skill_berserk = false;
        NextButton.SetActive(true);
    }
    public void ChooseSkill12()
    {
        Skills.skill_airattack = false;
        Skills.skill_automissile = false;
        Skills.skill_berserk = true;
        NextButton.SetActive(true);
    }
    public void ChooseSkill13()
    {
        Skills.skill_obstacle = true;
        Skills.skill_corehealing = false;
        Skills.skill_coreheat = false;
        NextButton.SetActive(true);
    }
    public void ChooseSkill14()
    {
        Skills.skill_obstacle = false;
        Skills.skill_corehealing = true;
        Skills.skill_coreheat = false;
        NextButton.SetActive(true);
    }
    public void ChooseSkill15()
    {
        Skills.skill_obstacle = false;
        Skills.skill_corehealing = false;
        Skills.skill_coreheat = true;
        NextButton.SetActive(true);
    }
}
