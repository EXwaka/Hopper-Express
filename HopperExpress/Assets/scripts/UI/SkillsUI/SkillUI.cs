using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Text GreekFireText;
    public GameObject GreekFireImg;
    private float GreekFireCD;

    void Start()
    {
        GreekFireImg.SetActive(false);
        CheckGreekFire();
    }

    // Update is called once per frame
    void Update()
    {
        GreekFire();
    }

    void CheckGreekFire()
    {
        if (Skills.skill_throwfire)
        {
            GreekFireImg.SetActive(true);
            GreekFireText.text = "";
            GreekFireCD = ThrowFire.greekFireCD;
        }

    }
    void GreekFire()
    {
        if(ThrowFire.Activated)
        {
            GreekFireCD -= Time.deltaTime;
            GreekFireText.text = GreekFireCD.ToString("F0");
        }
        else if(!ThrowFire.Activated)
        {
            GreekFireText.text = "";
            GreekFireCD = ThrowFire.greekFireCD;
        }
    }
}
