using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Cinemachine;
using Unity.Burst.Intrinsics;
using System.Linq;
using Unity.VisualScripting;

public class SkillSelectUI : MonoBehaviour
{
    [SerializeField] List<UpgradeDeta> upgrades;
    [SerializeField] List<UpgradeButton> upgradeButtons;
    List<UpgradeDeta> selectedUpgrades;
    [SerializeField]List<UpgradeDeta> acquiredUpgrades;

    public GameObject SkillMenu;

    public RectTransform rectTransform;
    public float topPosY, middlePosY;
    public float tweenDuration;
    public bool okButton=false;
    public GameObject NextButton;
    private CinemachineBrain cinemachineBrain;
    private bool slideIn=false;


    // Start is called before the first frame update
    void Start()
    {
        SkillMenu.SetActive(false);
        okButton = false;
        NextButton.SetActive(false); 
        slideIn = false;
        cinemachineBrain = FindObjectOfType<CinemachineBrain>();
        HideButtons();
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (FindObjectsOfType<SkillSelectUI>().Length > 1)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("TimeScale" + Time.timeScale);
        if (Timer.timeLeft <= 1 && Wavespawner.monsCount <= 0)
        {
            SkillMenu.SetActive(true);
            if(!slideIn)
            {
                StartCoroutine(SlideIn());
                slideIn = true;
            }
        }

        //else if (okButton == false)
        //{
        //    Time.timeScale = 1f; 
        //}

    }
    public void OpenPanel(List<UpgradeDeta> upgradeDetas)
    {
        Clean();
        if (selectedUpgrades == null)
        {
            selectedUpgrades = new List<UpgradeDeta>();
        }
        selectedUpgrades.Clear();
        selectedUpgrades.AddRange(GetUpgrades(3));

        for(int i = 0; i < upgradeDetas.Count; i++)
        {
            upgradeButtons[i].gameObject.SetActive(true);
            upgradeButtons[i].Set(upgradeDetas[i]);
        }
    }

    public void Clean()
    {
        for (int i = 0; i < upgradeButtons.Count; i++)
        {
            upgradeButtons[i].Clean();
        }
    }

    IEnumerator SlideIn()
    {
        Time.timeScale = 0.2f; 
        yield return new WaitForSecondsRealtime(1f);
        OpenPanel(GetUpgrades(3));//choose 3 skills in the slot
        if (cinemachineBrain != null)
        {
            cinemachineBrain.enabled = false;
        }
        Time.timeScale = 0f; 
        rectTransform.DOAnchorPosY(middlePosY, tweenDuration).SetUpdate(true);
    }


    public void SlideOut()
    {
        HideButtons();
        cinemachineBrain.enabled = true;
        Time.timeScale = 1f;

        SkillMenu.SetActive(false);
        okButton = false;
        NextButton.SetActive(false);
        slideIn = false;
        cinemachineBrain = FindObjectOfType<CinemachineBrain>();
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, topPosY);

        gameObject.TryGetComponent<Timer>(out Timer timer);
        {
            timer.ResetTimer();

        }

        SceneController.instance.NextLevel();

    }

    public void HideButtons()
    {
        for (int i = 0; i < upgradeButtons.Count; i++)
        {
            upgradeButtons[i].gameObject.SetActive(false);
        }
    }
    public List<UpgradeDeta> GetUpgrades(int count)
    {
        List<UpgradeDeta> upgradeList = new List<UpgradeDeta>();

        if (count > upgrades.Count)
        {
            count = upgrades.Count;// if run out of skills request, give all skills left 
        }

        for(int i = 0; i<count; i++)
        {
            upgradeList.Add(upgrades[Random.Range(0, upgrades.Count)]);

        }
        return upgradeList;

    }

    public void Upgrade(int selectedUpgradeID)
    {
        UpgradeDeta upgradeDeta = selectedUpgrades[selectedUpgradeID];
        if(acquiredUpgrades==null)
        {
            acquiredUpgrades = new List<UpgradeDeta>();
        }
        acquiredUpgrades.Add(upgradeDeta);
        upgrades.Remove(upgradeDeta);
    }
    // =============DO NOT DELETE THIS!=============
    // Choose Skill System
    //public void ChooseSkill1()
    //{
    //    Skills.skill_forcefield = false;
    //    Skills.skill_electricfance = false;
    //    Skills.skill_floorspike = false;
    //    NextButton.SetActive(true);

    //}
    //public void ChooseSkill2()
    //{
    //    Skills.skill_forcefield = false;
    //    Skills.skill_electricfance = true;
    //    Skills.skill_floorspike = false;
    //    NextButton.SetActive(true);


    //}
    //public void ChooseSkill3()
    //{
    //    Skills.skill_forcefield = false;
    //    Skills.skill_electricfance = false;
    //    Skills.skill_floorspike = true;
    //    NextButton.SetActive(true);

    //}
    //public void ChooseSkill4()
    //{
    //    Skills.skill_throwfire = true;
    //    Skills.skill_throwice = false;
    //    Skills.skill_airattack = false;
    //    NextButton.SetActive(true);

    //}
    //public void ChooseSkill5()
    //{
    //    Skills.skill_throwfire = false;
    //    Skills.skill_throwice = true;
    //    Skills.skill_airattack = false;
    //    NextButton.SetActive(true);

    //}
    //public void ChooseSkill6()
    //{
    //    Skills.skill_throwfire = false;
    //    Skills.skill_throwice = false;
    //    Skills.skill_airattack = true;
    //    NextButton.SetActive(true);

    //}
    // =============DO NOT DELETE THIS!=============

}
